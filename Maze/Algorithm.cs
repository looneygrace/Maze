using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JetBrains.Annotations;
using NPOI.SS.Formula.Functions;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Threading;

namespace Maze
{
    public abstract class Cell
    {

        // Position in the maze

        public int Row { get; }

        public int Column { get; }

        public Point Location => new Point(Column, Row);

        // Cells that are linked to this cell

        private readonly Dictionary<Cell, bool> _links;

        public List<Cell> Links => _links.Keys.ToList();

        public abstract List<Cell> Neighbors { get; }



        public int Weight { get; set; }



        public Cell(int row, int col)
        {

            Row = row;

            Column = col;

            Weight = 1;

            _links = new Dictionary<Cell, bool>();

        }



        public virtual void Link(Cell cell, bool bidirectional = true)
        {
            _links[cell] = true;
            if (bidirectional)
            {
                cell.Link(this, false);
            }

        }

        public virtual void Unlink(Cell cell, bool bidirectional = true)
        {

            _links.Remove(cell);

            if (bidirectional)
            {

                cell.Unlink(this, false);

            }

        }

        public bool IsLinked(Cell cell)
        {

            if (cell == null)
            {

                return false;

            }

            return _links.ContainsKey(cell);

        }



        public Distances Distances
        {

            get
            {

                var distances = new Distances(this);

                var frontier = new HashSet<Cell> {

                    this

                };



                while (frontier.Any())
                {

                    var newFrontier = new HashSet<Cell>();



                    foreach (var cell in frontier)
                    {

                        foreach (var linked in cell.Links)
                        {

                            if (distances[linked] >= 0)
                            {

                                continue;

                            }

                            distances[linked] = distances[cell] + 1;

                            newFrontier.Add(linked);

                        }

                    }

                    frontier = newFrontier;

                }

                return distances;

            }

        }



        public Distances WeightedDistances
        {

            get
            {

                var weights = new Distances(this);

                var pending = new HashSet<Cell> { this };



                while (pending.Any())
                {

                    var cell = pending.OrderBy(c => weights[c]).First();

                    pending.Remove(cell);



                    foreach (var neighbor in cell.Links)
                    {

                        var totalWeight = weights[cell] + neighbor.Weight;

                        if (weights[neighbor] >= 0 || totalWeight < weights[neighbor])
                        {

                            pending.Add(neighbor);

                            weights[neighbor] = totalWeight;

                        }

                    }

                }



                return weights;

            }

        }

    }
    public class CartesianCell : Cell
    {
        // Neighboring cells
        [CanBeNull]
        public CartesianCell North { get; set; }
        [CanBeNull]
        public CartesianCell South { get; set; }
        [CanBeNull]
        public CartesianCell East { get; set; }
        [CanBeNull]
        public CartesianCell West { get; set; }
        public override List<Cell> Neighbors => new Cell[] { North, South, East, West }.Where(c => c != null).ToList();
        public CartesianCell(int row, int col) : base(row, col)
        {

        }



        public Point Center(int cellSize)
        {

            var cx = Column * cellSize + cellSize / 2;

            var cy = Row * cellSize + cellSize / 2;



            return new Point(cx, cy);

        }

        public virtual bool HorizontalPassage => false;

        public virtual bool VerticalPassage => false;

    }
    public enum DrawMode
    {
        Background,
        Walls,

        Path

    }

    public interface IMazeAlgorithm
    {

        bool Step();

        Cell CurrentCell { get; }

    }
    public class BinaryTree : IMazeAlgorithm
    {

        private readonly Grid _grid;

        private readonly IEnumerator<Cell> _currentCell;

        public Cell CurrentCell => _currentCell.Current;



        private readonly Random _rand;



        public static Grid Maze(Grid grid, int seed = -1)
        {

            var rand = seed >= 0 ? new Random(seed) : new Random();

            foreach (var cell in grid.Cells)
            {

                var neighbors = GetNeighbors(cell);



                if (!neighbors.Any())
                {

                    continue;

                }

                var neighbor = neighbors.Sample(rand);

                if (neighbor != null)
                {

                    cell.Link(neighbor);

                }

            }

            return grid;

        }



        private static List<Cell> GetNeighbors(Cell cell)
        {
            switch (cell)
            {
                case CartesianCell cartesianCell:
                    return new Cell[] { cartesianCell.North, cartesianCell.East }.Where(c => c != null).ToList();
            }

            return new List<Cell>();
        }



        public BinaryTree(Grid grid, int seed = -1)
        {

            _grid = grid;

            _currentCell = _grid.Cells.GetEnumerator();

            _rand = seed >= 0 ? new Random(seed) : new Random();

        }

        public bool Step()
        {

            var last = _currentCell.Current;

            _currentCell.MoveNext();

            var cell = _currentCell.Current;

            if (cell != null)
            {

                var neighbors = GetNeighbors(cell);

                if (neighbors.Any())
                {

                    var neighbor = neighbors.Sample(_rand);

                    if (neighbor != null)
                    {

                        cell.Link(neighbor);

                    }

                }

            }

            return last != _currentCell.Current;

        }

    }
    public interface IGrid
    {

        Cell RandomCell(Random random = null);

        Cell this[int row, int column] { get; }

        int Rows { get; }

        int Columns { get; }

        Image ToImg(int cellSize = 50, float insetPrc = 0.0f);

        void Braid(double p = 1.0f);

    }

    public class Grid : IGrid
    {

        // Dimensions of the grid

        public int Rows { get; }

        public int Columns { get; }

        public virtual int Size => Rows * Columns;



        // The actual grid

        protected List<List<Cell>> _grid;



        public Cell ActiveCell { get; set; }



        [CanBeNull]

        public virtual Cell this[int row, int column]
        {
            get
            {
                if (row < 0 || row >= Rows)
                {
                    return null;
                }
                if (column < 0 || column >= Columns)
                {
                    return null;
                }

                return _grid[row][column];

            }

        }

        [NotNull]

        public virtual Cell RandomCell(Random random = null)
        {



            var rand = random ?? new Random();

            var row = rand.Next(Rows);

            var col = rand.Next(Columns);

            var randomCell = this[row, col];

            if (randomCell == null)
            {

                throw new InvalidOperationException("Random cell is null");

            }

            return randomCell;

        }

        // Row iterator

        public IEnumerable<List<Cell>> Row
        {

            get
            {

                foreach (var row in _grid)
                {

                    yield return row;

                }

            }

        }

        // Cell iterator

        public virtual IEnumerable<Cell> Cells
        {

            get
            {

                foreach (var row in Row)
                {

                    foreach (var cell in row)
                    {

                        if (cell != null)
                        {

                            yield return cell;

                        }

                    }

                }

            }

        }



        public Grid(int rows, int cols)
        {

            Rows = rows;

            Columns = cols;



            PrepareGrid();

            ConfigureCells();

        }



        private void PrepareGrid()
        {

            _grid = new List<List<Cell>>();

            for (var r = 0; r < Rows; r++)
            {

                var row = new List<Cell>();

                for (var c = 0; c < Columns; c++)
                {

                    row.Add(new CartesianCell(r, c));

                }

                _grid.Add(row);

            }

        }



        private void ConfigureCells()
        {

            foreach (var cell in Cells.Cast<CartesianCell>())
            {

                var row = cell.Row;

                var col = cell.Column;



                cell.North = (CartesianCell)this[row - 1, col];

                cell.South = (CartesianCell)this[row + 1, col];

                cell.West = (CartesianCell)this[row, col - 1];

                cell.East = (CartesianCell)this[row, col + 1];

            }

        }



        public override string ToString()
        {

            var output = new StringBuilder("+");

            for (var i = 0; i < Columns; i++)
            {

                output.Append("---+");

            }

            output.AppendLine();



            foreach (var row in Row)
            {

                var top = "|";

                var bottom = "+";

                foreach (var cell in row.Cast<CartesianCell>())
                {

                    var body = $" {ContentsOf(cell)} ";

                    var east = cell.IsLinked(cell.East) ? " " : "|";



                    top += body + east;



                    var south = cell.IsLinked(cell.South) ? "   " : "---";

                    const string corner = "+";

                    bottom += south + corner;

                }

                output.AppendLine(top);

                output.AppendLine(bottom);

            }



            return output.ToString();

        }



        protected virtual string ContentsOf(Cell cell)
        {

            return " ";

        }



        public virtual Image ToImg(int cellSize = 50, float insetPrc = 0.0f)
        {
            var width = cellSize * Columns;
            var height = cellSize * Rows;
            var inset = (int)(cellSize * 0);      
            var img = new Bitmap(width, height);
            using (var g = Graphics.FromImage(img))
            {
                g.Clear(Color.Transparent);
                foreach (var mode in new[] { DrawMode.Background, DrawMode.Walls, DrawMode.Path, })
                {
                   
                    foreach (var cell in Cells.Cast<CartesianCell>())
                    {
                        var x = cell.Column * cellSize;
                        var y = cell.Row * cellSize;                      

                            ToImgWithoutInset(g, cell, mode, cellSize, x, y);
                        
                    }
                }
            }
            return img;
        }
        protected virtual void ToImgWithInset(Graphics g, CartesianCell cell, DrawMode mode, int cellSize, int x, int y, int inset)
        {
            Console.WriteLine("ERRROR");
        }
                private void ToImgWithoutInset(Graphics g, CartesianCell cell, DrawMode mode, int cellSize, int x, int y)
        {
            var x1 = x;
            var y1 = y;
            var x2 = x1 + cellSize;
            var y2 = y1 + cellSize;
            if (cell.Neighbors.Count == 0)
            {
                return;
            }

            if (mode == DrawMode.Background)
            {

                var color = BackgroundColorFor(cell);

                if (color != null)
                {

                    g.FillRectangle(new SolidBrush(color.GetValueOrDefault()), x1, y1, cellSize, cellSize);

                }

            }
            else if (mode == DrawMode.Walls)
            {

                if (cell.North == null)
                {

                    g.DrawLine(Pens.Black, x1, y1, x2, y1);

                }

                if (cell.West == null)
                {

                    g.DrawLine(Pens.Black, x1, y1, x1, y2);

                }



                if (!cell.IsLinked(cell.East))
                {

                    g.DrawLine(Pens.Black, x2, y1, x2, y2);

                }

                if (!cell.IsLinked(cell.South))
                {

                    g.DrawLine(Pens.Black, x1, y2, x2, y2);

                }



                if (cell == ActiveCell)
                {

                    g.FillRectangle(Brushes.GreenYellow, x1 + 2, y1 + 2, cellSize - 4, cellSize - 4);

                }



            }
            else if (mode == DrawMode.Path)
            {

                DrawPath(cell, g, cellSize);

            }

        }



        protected virtual void DrawPath(Cell cell, Graphics g, int cellSize)
        {

        }



        protected virtual Color? BackgroundColorFor(Cell cell)
        {

            return Color.White;

        }







        public List<Cell> Deadends()
        {
            return Cells.Where(c => c.Links.Count == 1).ToList();
        }

        public void Braid(double p = 1.0f)
        {
            var rand = new Random();
            foreach (var cell in Deadends().Shuffle())
            {
                if (cell.Links.Count != 1 || rand.NextDouble() > p)
                {
                    continue;
                }
                var neighbors = cell.Neighbors.Where(n => !cell.IsLinked(n)).ToList();
                var best = neighbors.Where(n => n.Links.Count == 1).ToList();
                if (!best.Any())
                {
                    best = neighbors;
                    if (!best.Any())
                    {
                        continue;
                    }

                }
                var neighbor = best.Sample(rand);
                cell.Link(neighbor);
            }
        }
    }
    public class Distances
    {
        private Cell Root { get; }
        private readonly Dictionary<Cell, int> _cells;
        public List<Cell> Cells => _cells.Keys.ToList();
        public Distances(Cell root)
        {
            Root = root;
            _cells = new Dictionary<Cell, int> {{Root, 0 }};
        }
        public int this[Cell cell]
        {get{
                if (_cells.ContainsKey(cell))
                {
                    return _cells[cell];
                    
                }

                return -1;



            }

            set => _cells[cell] = value;

        }





        public Distances PathTo(Cell goal)
        {

            var current = goal;

            var breadcrumbs = new Distances(Root)
            {

                [current] = _cells[current]

            };



            while (current != Root)
            {
                foreach (var neighbor in current.Links)
                {
                    if (_cells[neighbor] < _cells[current])
                    {
                        breadcrumbs[neighbor] = _cells[neighbor];
                        current = neighbor;
                        break;
                    }
                }
            }
            return breadcrumbs;
        }

        public (Cell maxCell, int maxDistance) Max
        {
            get
            {
                var maxDistance = 0;
                var maxCell = Root;
                foreach (var cell in _cells)
                { 
                    if (cell.Value > maxDistance)
                    {

                        maxDistance = cell.Value;

                        maxCell = cell.Key;

                    }

                }

                return (maxCell, maxDistance);

            }
        }
    }
    public interface IPathGrid : IColoredGrid
    {

        int PathLength { get; }

        Distances Path { get; set; }

    }
    public interface IColoredGrid : IGrid
    {

        Color BackColor { get; set; }

        Distances Distances { get; set; }

    }
    public class PolarGrid : Grid
    {

        public PolarGrid(int rows) : base(rows, 1)
        {
            PrepareGrid();

            ConfigureCells();

        }



        private void PrepareGrid()
        {

            var rows = new List<List<Cell>>();

            var rowHeight = 1.0 / Rows;

            rows.Add(new List<Cell> { new PolarCell(0, 0) });



            for (var row = 1; row < Rows; row++)
            {

                var newRow = new List<Cell>();

                var radius = (double)row / Rows;

                var circumference = 2 * Math.PI * radius;



                var previousCount = rows[row - 1].Count;

                var estimatedCellWidth = circumference / previousCount;

                var ratio = (int)Math.Round(estimatedCellWidth / rowHeight);

                var cells = previousCount * ratio;

                for (var col = 0; col < cells; col++)
                {

                    newRow.Add(new PolarCell(row, col));

                }

                rows.Add(newRow);

            }

            _grid = rows;

        }

        private void ConfigureCells()
        {

            foreach (var cell in Cells)
            {

                var pCell = (PolarCell)cell;

                var row = cell.Row;

                var col = cell.Column;

                if (row > 0)
                {

                    pCell.Clockwise = (PolarCell)this[row, col + 1];

                    pCell.CounterClockwise = (PolarCell)this[row, col - 1];

                    var ratio = _grid[row].Count / _grid[row - 1].Count;

                    var parent = (PolarCell)_grid[row - 1][col / ratio];

                    parent.Outward.Add((PolarCell)cell);

                    pCell.Inward = parent;

                }

            }

        }



        public override int Size
        {

            get
            {

                return _grid.Aggregate(0, (total, list) => total + list.Count);

            }

        }

        public override Cell RandomCell(Random random = null)
        {

            var rand = random ?? new Random();

            var row = rand.Next(Rows);

            var col = rand.Next(_grid[row].Count);

            var randomCell = _grid[row][col];

            if (randomCell == null)
            {

                throw new InvalidOperationException("Random cell is null");

            }

            return randomCell;

        }

        public override Cell this[int row, int column]
        {

            get
            {

                if (row < 0 || row >= Rows)
                {

                    return null;

                }

                if (column < 0)
                {

                    column = _grid[row].Count - 1;

                }



                return _grid[row][column % _grid[row].Count];

            }

        }



        public override Image ToImg(int cellSize = 50, float insetPrc = 0.0f)
        {

            var imgSize = 2 * Rows * cellSize;

            var center = imgSize / 2;



            var img = new Bitmap(imgSize + 1, imgSize + 1);

            using (var g = Graphics.FromImage(img))
            {



                g.Clear(Color.White);

                foreach (var mode in new[] { DrawMode.Background, DrawMode.Walls, DrawMode.Path, })
                {

                    foreach (var cell in Cells.Cast<PolarCell>())
                    {

                        var theta = 2 * Math.PI / _grid[cell.Row].Count;

                        var innerRadius = cell.Row * cellSize;

                        var outerRadius = (cell.Row + 1) * cellSize;

                        var thetaCCW = cell.Column * theta;

                        var thetaCW = (cell.Column + 1) * theta;



                        var ax = center + (float)(innerRadius * Math.Cos(thetaCCW));

                        var ay = center + (float)(innerRadius * Math.Sin(thetaCCW));

                        var bx = center + (float)(outerRadius * Math.Cos(thetaCCW));

                        var by = center + (float)(outerRadius * Math.Sin(thetaCCW));

                        var cx = center + (float)(innerRadius * Math.Cos(thetaCW));

                        var cy = center + (float)(innerRadius * Math.Sin(thetaCW));

                        var dx = center + (float)(outerRadius * Math.Cos(thetaCW));

                        var dy = center + (float)(outerRadius * Math.Sin(thetaCW));



                        var thetaCCWDegrees = (float)(thetaCCW * 180 / Math.PI);

                        var thetaCWDegrees = (float)(thetaCW * 180 / Math.PI);

                        var sweep = (float)(theta * 180 / Math.PI);

                        if (mode == DrawMode.Walls)
                        {

                            if (cell == ActiveCell)
                            {

                                if (cell.Inward == null)
                                {

                                    g.FillEllipse(Brushes.GreenYellow, center - outerRadius, center - outerRadius, outerRadius * 2, outerRadius * 2);

                                }
                                else
                                {

                                    using (var path = new GraphicsPath())
                                    {

                                        path.AddLine(cx, cy, dx, dy);

                                        //path.AddLine(dx, dy, bx, by);

                                        path.AddArc(center - outerRadius, center - outerRadius, outerRadius * 2, outerRadius * 2, thetaCWDegrees, -sweep);

                                        path.AddLine(ax, ay, bx, by);

                                        //path.AddLine(ax, ay, cx, cy);

                                        path.AddArc(center - innerRadius, center - innerRadius, innerRadius * 2, innerRadius * 2, thetaCCWDegrees, sweep);



                                        path.CloseFigure();

                                        g.FillPath(Brushes.GreenYellow, path);

                                    }

                                }

                            }

                            if (cell.Row != 0)
                            {

                                if (!cell.IsLinked(cell.Inward))
                                {

                                    //g.DrawLine(Pens.Black, ax, ay, cx, cy);

                                    g.DrawArc(Pens.Black, center - innerRadius, center - innerRadius, innerRadius * 2, innerRadius * 2, thetaCCWDegrees, sweep);



                                }

                                if (!cell.IsLinked(cell.Clockwise))
                                {

                                    g.DrawLine(Pens.Black, cx, cy, dx, dy);

                                }

                            }



                        }
                        else if (mode == DrawMode.Background)
                        {

                            var color = BackgroundColorFor(cell);

                            if (color != null)
                            {

                                using (var path = new GraphicsPath())
                                {

                                    if (cell.Inward == null)
                                    {

                                        g.FillEllipse(new SolidBrush(color.GetValueOrDefault()), center - outerRadius, center - outerRadius, outerRadius * 2, outerRadius * 2);

                                    }
                                    else
                                    {

                                        path.AddLine(cx, cy, dx, dy);

                                        //path.AddLine(dx, dy, bx, by);

                                        path.AddArc(center - outerRadius, center - outerRadius, outerRadius * 2, outerRadius * 2, thetaCWDegrees, -sweep);

                                        path.AddLine(ax, ay, bx, by);

                                        //path.AddLine(ax, ay, cx, cy);

                                        path.AddArc(center - innerRadius, center - innerRadius, innerRadius * 2, innerRadius * 2, thetaCCWDegrees, sweep);



                                        path.CloseFigure();

                                        g.FillPath(new SolidBrush(color.GetValueOrDefault()), path);

                                        g.DrawPath(new Pen(color.GetValueOrDefault()), path);

                                    }

                                }

                            }

                        }
                        else if (mode == DrawMode.Path)
                        {

                            DrawPath(cell, g, cellSize);

                        }

                    }

                    g.DrawEllipse(Pens.Black, center - Rows * cellSize, center - Rows * cellSize, Rows * cellSize * 2, Rows * cellSize * 2);

                }

            }

            return img;

        }

    }
    public class ColoredPolarGrid : PolarGrid, IColoredGrid
    {

        private Distances _distances;

        private Cell _farthest;

        private int _maximum;



        public Color BackColor { get; set; }



        public ColoredPolarGrid(int rows) : base(rows)
        {

            BackColor = Color.Green;

        }

        public Distances Distances
        {

            get => _distances;

            set
            {

                _distances = value;

                (_farthest, _maximum) = value.Max;

            }

        }



        protected override Color? BackgroundColorFor(Cell cell)
        {

            if (Distances == null || Distances[cell] < 0)
            {

                return null;

            }

            var distance = Distances[cell];

            var intensity = (_maximum - distance) / (float)_maximum;



            return BackColor.Scale(intensity);

        }

    }
    public static class ColorExtensions
    {

        public static Color Scale(this Color color, float intensity)
        {

            return Color.FromArgb(

                                  (int)(color.R + (255 - color.R) * intensity),

                                  (int)(color.G + (255 - color.G) * intensity),

                                  (int)(color.B + (255 - color.B) * intensity)

                                 );

        }

        public static Color Invert(this Color color)
        {

            return Color.FromArgb(color.ToArgb() ^ 0xffffff);

        }

    }
    public class PolarCell : Cell
    {
        [CanBeNull]
        public PolarCell Clockwise { get; set; }
        [CanBeNull]
        public PolarCell CounterClockwise { get; set; }
        [CanBeNull]
        public PolarCell Inward { get; set; }
        [NotNull]
        public List<PolarCell> Outward { get; }
        public PolarCell(int row, int col) : base(row, col)
        {

            Outward = new List<PolarCell>();

        }
        public override List<Cell> Neighbors
        {

            get
            {

                var neighbors = new List<Cell> {

                    Clockwise,

                    CounterClockwise,

                    Inward

                };

                neighbors.AddRange(Outward);

                return neighbors.Where(c => c != null).ToList();

            }

        }
        public Point Center(int center, double theta, int cellSize)
        {

            var innerRadius = Row * cellSize;

            var outerRadius = (Row + 1) * cellSize;

            var thetaCCW = Column * theta;

            var thetaCW = (Column + 1) * theta;



            var ax = center + (float)(innerRadius * Math.Cos(thetaCCW));

            var ay = center + (float)(innerRadius * Math.Sin(thetaCCW));

            var bx = center + (float)(outerRadius * Math.Cos(thetaCCW));

            var by = center + (float)(outerRadius * Math.Sin(thetaCCW));

            var cx = center + (float)(innerRadius * Math.Cos(thetaCW));

            var cy = center + (float)(innerRadius * Math.Sin(thetaCW));

            var dx = center + (float)(outerRadius * Math.Cos(thetaCW));

            var dy = center + (float)(outerRadius * Math.Sin(thetaCW));



            var thetaCCWDegrees = (float)(thetaCCW * 180 / Math.PI);

            var thetaCWDegrees = (float)(thetaCW * 180 / Math.PI);

            var sweep = (float)(theta * 180 / Math.PI);



            using (var path = new GraphicsPath())
            {

                if (Inward == null)
                {

                    path.AddEllipse(center - outerRadius, center - outerRadius, outerRadius * 2, outerRadius * 2);

                }
                else
                {

                    path.AddLine(cx, cy, dx, dy);

                    //path.AddLine(dx, dy, bx, by);

                    path.AddArc(center - outerRadius, center - outerRadius, outerRadius * 2, outerRadius * 2, thetaCWDegrees, -sweep);

                    path.AddLine(ax, ay, bx, by);

                    //path.AddLine(ax, ay, cx, cy);

                    path.AddArc(center - innerRadius, center - innerRadius, innerRadius * 2, innerRadius * 2, thetaCCWDegrees, sweep);



                    path.CloseFigure();

                }

                var bounds = path.GetBounds();



                return new Point((int)(bounds.Left + bounds.Width / 2), (int)(bounds.Top + bounds.Height / 2));

            }

        }

    }

    public class ColoredGrid : Grid, IColoredGrid
    {
        private Distances _distances;
        private Cell _farthest;
        private int _maximum;

        public ColoredGrid(int rows, int cols) : base(rows, cols)
        {
            BackColor = Color.Green;
        }

        public Color BackColor { get; set; }

        public Distances Distances
        {
            get => _distances;
            set
            {
                _distances = value;
                (_farthest, _maximum) = value.Max;
            }
        }

        protected override Color? BackgroundColorFor(Cell cell)
        {
            if (Distances == null || Distances[cell] < 0)
            {
                return null;
            }
            var distance = Distances[cell];
            var intensity = (_maximum - distance) / (float)_maximum;

            return BackColor.Scale(intensity);
        }
    }
    public class ColoredPathGrid : ColoredGrid, IPathGrid
    {
        public ColoredPathGrid(int rows, int cols) : base(rows, cols) { }

        private Distances _path;
        private Cell _end;
        private int _maxDistance;

        public Distances Path
        {
            get => _path;
            set
            {
                _path = value;
                (_end, _maxDistance) = value.Max;
            }
        }
        public int PathLength => _maxDistance + 1;

        protected override void DrawPath(Cell cell, Graphics g, int cellSize)
        {
            if (Path == null)
            {
                return;
            }
            DrawPathInternal((CartesianCell)cell, g, cellSize);
        }

        private void DrawPathInternal(CartesianCell cell, Graphics g, int cellSize)
        {
            var thisDistance = Path[cell];
            if (thisDistance < 0)
                return;
            var center = cell.Center(cellSize);
            using (var pen = new Pen(BackColor.Invert(), 2))
            {

                if (cell.North != null && (Path[cell.North] == thisDistance + 1 || Path[cell.North] == thisDistance - 1 && thisDistance != 0))
                {
                    g.DrawLine(pen, center, cell.North.Center(cellSize));
                }

                if (cell.East != null && (Path[cell.East] == thisDistance + 1 || Path[cell.East] == thisDistance - 1 && thisDistance != 0))
                {
                    g.DrawLine(pen, center, cell.East.Center(cellSize));
                }

                if (thisDistance == 0)
                {
                    g.DrawRectangle(pen, center.X - 2, center.Y - 2, 4, 4);
                }
                if (thisDistance == _maxDistance)
                {
                    g.DrawLine(pen, center.X - 4, center.Y - 4, center.X + 4, center.Y + 4);
                    g.DrawLine(pen, center.X + 4, center.Y - 4, center.X - 4, center.Y + 4);
                }
            }
        }
    }
    public class ColoredPathPolarGrid : ColoredPolarGrid, IPathGrid
    {
        public ColoredPathPolarGrid(int rows) : base(rows) { }

        private Distances _path;
        private Cell _end;
        private int _maxDistance;
        public Distances Path
        {

            get => _path;

            set
            {

                _path = value;

                (_end, _maxDistance) = value.Max;

            }

        }
        public int PathLength => _maxDistance + 1;
        protected override void DrawPath(Cell cell, Graphics g, int cellSize)
        {
            if (Path == null)
            {
                return;
            }
            DrawPathInternal((PolarCell)cell, g, cellSize);
        }



        private void DrawPathInternal(PolarCell cell, Graphics g, int cellSize)
        {
            var thisDistance = Path[cell];
            if (thisDistance < 0)

                return;



            var imgSize = 2 * Rows * cellSize;

            var center = imgSize / 2;

            var theta = 2 * Math.PI / _grid[cell.Row].Count;



            var centerCell = cell.Center(center, theta, cellSize);



            using (var pen = new Pen(BackColor.Invert(), 2))
            {

                if (cell.Inward != null && (Path[cell.Inward] == thisDistance + 1 || Path[cell.Inward] == thisDistance - 1 && thisDistance != 0))
                {

                    var theta2 = 2 * Math.PI / _grid[cell.Inward.Row].Count;

                    var bounds = cell.Inward.Center(center, theta2, cellSize);

                    g.DrawLine(pen, centerCell, bounds);

                }

                if (cell.CounterClockwise != null && (Path[cell.CounterClockwise] == thisDistance + 1 || Path[cell.CounterClockwise] == thisDistance - 1 && thisDistance != 0))
                {

                    var theta2 = 2 * Math.PI / _grid[cell.CounterClockwise.Row].Count;

                    var bounds = cell.CounterClockwise.Center(center, theta2, cellSize);

                    g.DrawLine(pen, centerCell, bounds);

                }

                if (thisDistance == 0)
                {

                    g.DrawRectangle(pen, centerCell.X - 2, centerCell.Y - 2, 4, 4);

                }

                if (thisDistance == _maxDistance)
                {

                    g.DrawLine(pen, centerCell.X - 4, centerCell.Y - 4, centerCell.X + 4, centerCell.Y + 4);

                    g.DrawLine(pen, centerCell.X + 4, centerCell.Y - 4, centerCell.X - 4, centerCell.Y + 4);

                }

            }

        }
    }
    public static class ListExtensions
    {
        public static T Sample<T>(this List<T> list, Random rand = null)
        {
            if (rand == null)
            {
                rand = new Random();
            }
            return list[rand.Next(list.Count)];
        }
        public static List<T> Shuffle<T>(this List<T> list)
        {
            var n = list.Count;
            while (n > 1)
            {
                n--;
                var k = ThreadSafeRandom.ThisThreadsRandom.Next(n + 1);
                var value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
            return list;
        }
    }
    public static class ThreadSafeRandom
    {
        // http://stackoverflow.com/a/1262619/978460
        [ThreadStatic] private static Random _local;

        public static Random ThisThreadsRandom => _local ?? (_local = new Random(unchecked(Environment.TickCount * 31 + Thread.CurrentThread.ManagedThreadId)));
    }

}
