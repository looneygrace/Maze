using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Diagnostics;
using System.Threading;
using System.ComponentModel;
//Timer code was adapted from https://stackoverflow.com/questions/8302590/running-stopwatch-in-textblock

namespace Maze
{
    /// <summary>
    /// Interaction logic for PlayGame.xaml
    /// </summary>
    public partial class PlayGame : Window
    {
        Game n;
        public PlayGame() { 
        

            n.makeMaze();
            InitializeComponent();
            this.Stopwatch = new Stopwatch();
            this.Stopwatch.Start();
            this._timer = new Timer(
                new TimerCallback((s) => this.FirePropertyChanged(this, new PropertyChangedEventArgs("Stopwatch"))),
                null, 1000, 1000);
            
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
        private int Xmin, Ymin, CellWid, CellHgt;

        private void btnCreate_Click(object sender, EventArgs e)
        {
            // Figure out the drawing geometry.
            int wid = int.Parse(txtWidth.Text);
            int hgt = int.Parse(txtHeight.Text);

            CellWid = picMaze.ClientSize.Width / (wid + 2);
            CellHgt = picMaze.ClientSize.Height / (hgt + 2);
            if (CellWid > CellHgt) CellWid = CellHgt;
            else CellHgt = CellWid;
            Xmin = (picMaze.ClientSize.Width - wid * CellWid) / 2;
            Ymin = (picMaze.ClientSize.Height - hgt * CellHgt) / 2;

            // Build the maze nodes.
            MazeNode[,] nodes = MakeNodes(wid, hgt);

            // Build the spanning tree.
            FindSpanningTree(nodes[0, 0]);

            // Display the maze.
            DisplayMaze(nodes);
        }
        private void Save_Click(object sender, RoutedEventArgs e)
        {

        }
        private void Pause_Click(object sender, RoutedEventArgs e)
        {

        }
        private void Exit_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
