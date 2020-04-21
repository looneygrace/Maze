using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Maze
{
    using System;
    using System.Drawing;
    using System.Reflection;
    using System.Threading;
    using System.Windows.Forms;

    

    public partial class MazeForm : Form
    {
        private int GridSize = 50;
        private const int MazeSize = 11;
        private Grid _grid;
        private IMazeAlgorithm _algorithm;
        private Point? _tempPoint;
        private Point? _startPoint;
        private Point? _endPoint;
        
        private bool IsAnimating;
        private MazeStyle _mode;

        public MazeForm()
        {
            Console.WriteLine("HEY");
            //InitializeComponent();
            _grid = new Grid(MazeSize, MazeSize);
            pbMaze.Image = _grid.ToImg(GridSize, GridSize);
            var it = typeof(IMazeAlgorithm);
            var algoNames = AppDomain.CurrentDomain.GetAssemblies().SelectMany(s => s.GetTypes())
                .Where(t => it.IsAssignableFrom(t) && t.IsClass).Select(t => t.Name).ToArray();
            
            SetAlgorithm();

            tsmiPickStart.Click += TsmiPickStartOnClick;
            tsmiPickEnd.Click += TsmiPickEndOnClick;

        }

        private void TsmiPickEndOnClick(object sender, EventArgs eventArgs)
        {
            
            _endPoint = _tempPoint;
            tsslEndPoint.Text = "End: " + _endPoint;
        }

        private void TsmiPickStartOnClick(object sender, EventArgs eventArgs)
        {
            
            _startPoint = _tempPoint;
            tsslStartPoint.Text = "Start: " + _startPoint;
        }

        private void pbMaze_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                _tempPoint = new Point(e.X / GridSize, e.Y / GridSize);
            }
        }

        private void DrawMaze(object sender, EventArgs e)
        {
            
            Image img;
            var grid = new Grid(MazeSize, MazeSize);
            if (!CreateSelectedMaze(grid))
            {
                return;
            }
            img = grid.ToImg(GridSize, GridSize);
            pbMaze.Image = img;
            
        }

        private bool CreateSelectedMaze(IGrid grid)
        {
            var algo = "BinaryTree";

            var type = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(t => t.Name == algo);
            

            type.GetMethod("Maze", new[] { typeof(Grid), typeof(int) }).Invoke(null, new object[] { grid, GridSize});

            

            return true;
        }

        private void ResetMaze(object sender, EventArgs e)
        {
            _grid = new Grid(MazeSize, MazeSize);
            
            pbMaze.Image = _grid.ToImg(GridSize, GridSize);
            
            _startPoint = null;
            tsslStartPoint.Text = "Start: " + _startPoint;
            _endPoint = null;
            tsslEndPoint.Text = "End: " + _endPoint;
            tsslPathLength.Text = "Path Length: ";
            IsAnimating = false;
        }

        private void SetAlgorithm()
        {
            var algo = "BinaryTree";

            var type = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(t => t.Name == algo);
            _algorithm = (IMazeAlgorithm)Activator.CreateInstance(type, _grid, GridSize);
        }

        private void StepMaze(object sender, EventArgs e)
        {
            _grid.ActiveCell = _algorithm.CurrentCell;
            pbMaze.Image = _grid.ToImg(GridSize, GridSize);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pbMaze.Image.Save(saveFileDialog1.FileName);
            }
        }

        private void btnPickColor_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                pbColor.BackColor = colorDialog1.Color;
            }
        }

        private void btnColorize_Click(object sender, EventArgs e)
        {
            
                IColoredGrid colorGrid = new ColoredGrid(MazeSize, MazeSize);          
                if (!CreateSelectedMaze(colorGrid))
                {
                    return;
                }
                Cell start;
                if (_startPoint.HasValue)
                    start = colorGrid[_startPoint.Value.Y, _startPoint.Value.X];
                
                else
                {
                    start = colorGrid[colorGrid.Rows / 2, colorGrid.Columns / 2];
                }
                colorGrid.Distances = start.Distances;

                colorGrid.BackColor = pbColor.BackColor;

                pbMaze.Image = colorGrid.ToImg(GridSize, GridSize);
            
        }

        private void btnDrawPath_Click(object sender, EventArgs e)
        {
            if (_startPoint == null || _endPoint == null || _mode != MazeStyle.Square)
            {
                return;
            }
            
            {
                var colorGrid = new ColoredPathGrid(MazeSize, MazeSize);

                if (!CreateSelectedMaze(colorGrid))
                {
                    return;
                }
                var start = colorGrid[_startPoint.Value.Y, _startPoint.Value.X];
                var end = colorGrid[_endPoint.Value.Y, _endPoint.Value.X];

                colorGrid.Distances = start.Distances;
                colorGrid.Path = start.Distances.PathTo(end);

                tsslPathLength.Text = "Path Length: " + colorGrid.PathLength;

                colorGrid.BackColor = pbColor.BackColor;

                pbMaze.Image = colorGrid.ToImg(GridSize, GridSize);
            }

        }

        

        private void btnAnimate_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            IsAnimating = true;
            while (_algorithm.Step() && IsAnimating)
            {
                _grid.ActiveCell = _algorithm.CurrentCell;
                pbMaze.Image = _grid.ToImg(GridSize, GridSize);

                Application.DoEvents();
                Thread.Sleep(100);
            }
            Cursor = Cursors.Default;
            IsAnimating = false;
        }



    }

    public enum MazeStyle
    {
        Square,
        Polar,
        Hex,
        Triangle,
        Upsilon,
        Weave
    }
}