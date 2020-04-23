using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;

    using maze.Algorithms;
    using maze.Core;

    using maze.Core.Cells;
    using maze.Core.Grids;
    using maze.Core.Grids.Cartesian;
    using maze.Core.Grids.Interfaces;
    using System.Diagnostics;
    using System.Reflection;
    using System.Threading;
    using Timer = System.Threading.Timer;
    using ImageProcessor.Processors;
    using maze.Core.Grids.Masked;
    using Mask = maze.Core.Mask;

    public partial class MazeForm : Form, INotifyPropertyChanged
    {
        private int GridSize = 50;
        private const int MazeSize = 11;
        private Grid _grid;
        private IMazeAlgorithm _algorithm;
        private Point? _tempPoint;
        private Point? _startPoint;
        private Point? _endPoint;
        private Random nudRNGSeed;
        private bool IsAnimating;
        private MazeStyle _mode;

        public MazeForm()
        {
            InitializeComponent();
            float nudInset = 0;
            _grid = new Grid(MazeSize, MazeSize);
            pbMaze.Image = _grid.ToImg(GridSize, (float)nudInset);
            nudRNGSeed = new Random();

            tsmiPickStart.Click += TsmiPickStartOnClick;
            tsmiPickEnd.Click += TsmiPickEndOnClick;
            pbMask.Image = null;
            cbAlgorithm.SelectedItem = cbAlgorithm.Items[0];
            if (cbAlgorithm.SelectedItem != null)
            {
                Image img;
                var grid = new Grid(MazeSize, MazeSize);
                if (pbMask.Image != null)
                {
                    var mask = Mask.FromBitmap((Bitmap)pbMask.Image);
                    grid = new MaskedGrid(mask);
                }
                if (!CreateSelectedMaze(grid))
                {
                    return;
                }
                img = grid.ToImg(GridSize, (float)nudInset);
                pbMaze.Image = img;
            }
        }

        private void TsmiPickEndOnClick(object sender, EventArgs eventArgs)
        {
            if (pbMask.Image != null)
            {
                return;
            }
            _endPoint = _tempPoint;
            tsslEndPoint.Text = "End: " + _endPoint;
        }

        private void TsmiPickStartOnClick(object sender, EventArgs eventArgs)
        {
            if (pbMask.Image != null)
            {
                return;
            }
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
            cbAlgorithm.SelectedItem = cbAlgorithm.Items[0];
            if (cbAlgorithm.SelectedItem != null)
            {
                Image img;
                var grid = new Grid(MazeSize, MazeSize);
                if (pbMask.Image != null)
                {
                    var mask = Mask.FromBitmap((Bitmap)pbMask.Image);
                    grid = new MaskedGrid(mask);
                }
                if (!CreateSelectedMaze(grid))
                {
                    return;
                }
                img = grid.ToImg(GridSize, (float)nudInset.Value);
                pbMaze.Image = img;
           
        }
        }

        private bool CreateSelectedMaze(IGrid grid)
        {
            var algo = (string)cbAlgorithm.SelectedItem;

            var type = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(t => t.Name == algo);
            if (type == null)
            {
                MessageBox.Show("No algorithm type for " + algo);
                return false;
            }
            if (pbMask.Image != null && (type == typeof(BinaryTree)))
            {
                MessageBox.Show("Cannot use masks with Sidewinder and BinaryTree algorithms");
            }
            int rand = nudRNGSeed.Next();
            type.GetMethod("Maze", new[] { typeof(Grid), typeof(int) }).Invoke(null, new object[] { grid, rand});

            grid.Braid((double)nudBraid.Value);

            return true;
        }

        private void ResetMaze(object sender, EventArgs e)
        {
            _grid = new Grid(MazeSize, MazeSize);
            if (pbMask.Image != null)
            {
                var mask = maze.Core.Mask.FromBitmap((Bitmap)pbMask.Image);
                _grid = new MaskedGrid(mask);
            }
            pbMaze.Image = _grid.ToImg(GridSize, (float)nudInset.Value);
            if (cbAlgorithm.SelectedItem != null)
            {
                SetAlgorithm();
            }
            btnStep.Enabled = true;
            _startPoint = null;
            tsslStartPoint.Text = "Start: " + _startPoint;
            _endPoint = null;
            tsslEndPoint.Text = "End: " + _endPoint;
            tsslPathLength.Text = "Path Length: ";
            IsAnimating = false;
        }

        private void SetAlgorithm()
        {
            var algo = (string)cbAlgorithm.SelectedItem;

            var type = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(t => t.Name == algo);
            if (type == null)
            {
                MessageBox.Show("No algorithm type for " + algo);
            }
            if (pbMask.Image != null && type == typeof(BinaryTree))
            {
                MessageBox.Show("Cannot use masks with Sidewinder and BinaryTree algorithms");
            }
            int rand = nudRNGSeed.Next();

            _algorithm = (IMazeAlgorithm)Activator.CreateInstance(type, _grid, rand);
        }

        private void StepMaze(object sender, EventArgs e)
        {
            if (!_algorithm.Step())
            {
                btnStep.Enabled = false;
            }
            _grid.ActiveCell = _algorithm.CurrentCell;
            pbMaze.Image = _grid.ToImg(GridSize, (float)nudInset.Value);
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
            if (cbAlgorithm.SelectedItem != null)
            {
                IColoredGrid colorGrid = new ColoredGrid(MazeSize, MazeSize);
                if (pbMask.Image != null)
                {
                    var mask = maze.Core.Mask.FromBitmap((Bitmap)pbMask.Image);
                    colorGrid = new MaskedColoredGrid(mask);
                }

                if (!CreateSelectedMaze(colorGrid))
                {
                    return;
                }
                Cell start;
                if (_startPoint.HasValue)
                    start = colorGrid[_startPoint.Value.Y, _startPoint.Value.X];
                else if (colorGrid is MaskedColoredGrid)
                {
                    start = colorGrid.RandomCell();
                }
                else
                {
                    start = colorGrid[colorGrid.Rows / 2, colorGrid.Columns / 2];
                }
                colorGrid.Distances = start.Distances;

                colorGrid.BackColor = pbColor.BackColor;

                pbMaze.Image = colorGrid.ToImg(GridSize, (float)nudInset.Value);
            }
        }

        private void btnDrawPath_Click(object sender, EventArgs e)
        {
            if (_startPoint == null || _endPoint == null || pbMask.Image != null || _mode != MazeStyle.Square)
            {
                return;
            }
            if (cbAlgorithm.SelectedItem != null)
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

                pbMaze.Image = colorGrid.ToImg(GridSize, (float)nudInset.Value);
            }

        }

        private void btnLongestPath_Click(object sender, EventArgs e)
        {
            if (cbAlgorithm.SelectedItem != null)
            {
                IPathGrid colorGrid = new ColoredPathGrid(MazeSize, MazeSize);
                if (pbMask.Image != null)
                {
                    var mask = maze.Core.Mask.FromBitmap((Bitmap)pbMask.Image);
                    colorGrid = new MaskedColoredPathGrid(mask);
                }
                if (!CreateSelectedMaze(colorGrid))
                {
                    return;
                }
                var start = colorGrid.RandomCell();
                var distances = start.Distances;
                var (newStart, distance) = distances.Max;
                start = newStart;
                distances = start.Distances;
                var (end, distance2) = distances.Max;

                _startPoint = start.Location;
                tsslStartPoint.Text = "Start: " + _startPoint;

                _endPoint = end.Location;
                tsslEndPoint.Text = "End: " + _endPoint;

                colorGrid.Distances = start.Distances;
                colorGrid.Path = start.Distances.PathTo(end);

                tsslPathLength.Text = "Path Length: " + colorGrid.PathLength;

                colorGrid.BackColor = pbColor.BackColor;

                pbMaze.Image = colorGrid.ToImg(GridSize, (float)nudInset.Value);
            }
        }

        private void btnAnimate_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            IsAnimating = true;
            while (_algorithm.Step() && IsAnimating)
            {
                _grid.ActiveCell = _algorithm.CurrentCell;
                pbMaze.Image = _grid.ToImg(GridSize, (float)nudInset.Value);

                Application.DoEvents();
                Thread.Sleep(100);
            }
            btnStep.Enabled = false;
            Cursor = Cursors.Default;
            IsAnimating = false;
        }

        private void btnLoadMask_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pbMask.Image = Image.FromFile(openFileDialog1.FileName);
                pbMaze.SizeMode = PictureBoxSizeMode.Zoom;
                pbMaze.Dock = DockStyle.Fill;
                ToggleDrawPathButton();
            }
            else
            {
                ClearMask();
            }
            ResetMaze(sender, e);
        }


        private void rbSquare_CheckedChanged(object sender, EventArgs e)
        {
            if (rbSquare.Checked)
            {
                _mode = MazeStyle.Square;
                GridSize = 50;
                ToggleDrawPathButton();

            }
            ToggleEnableMaskButton();
            ResetMaze(sender, e);
        }

        private void ToggleEnableMaskButton()
        {
            if (_mode == MazeStyle.Square)
            {
                btnLoadMask.Enabled = true;
            }
            else
            {
                btnLoadMask.Enabled = false;
            }
        }

        private void ClearMask()
        {
            pbMask.Image?.Dispose();
            pbMask.Image = null;
            pbMaze.SizeMode = PictureBoxSizeMode.AutoSize;
            pbMaze.Dock = DockStyle.None;
            ToggleDrawPathButton();
        }

        private void ToggleDrawPathButton()
        {
            if (_mode == MazeStyle.Square && pbMask.Image == null)
            {
                btnDrawPath.Enabled = true;
            }
            else
            {
                btnDrawPath.Enabled = false;
            }
        }
    

    public enum MazeStyle
    {
        Square,
    }
    private void FirePropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(sender, e);
            }
        }

        private Timer _timer;

        public Stopwatch Stopwatch { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        private void Save_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to save your progress?", "Confirmation", System.Windows.Forms.MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                //string saveLocation = "1";
                //TODO: Ask where to save

                //n.Save(saveLocation);
                var MainWin = new MainWindow();
                MainWin.Show();
                this.Close();

            }
            else
            {
                // Do not close the window  
            }
        }
        private void Pause_Click(object sender, EventArgs e)
        {
           //TODO: actually pause timer

        }
        private void Exit_Click(object sender, EventArgs e)
        {
            var MainWin = new MainWindow();
            MainWin.Show();
            this.Close();
        }
    }
}