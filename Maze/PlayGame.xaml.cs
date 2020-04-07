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
    public partial class PlayGame : Window, INotifyPropertyChanged
    {
        Game n;
        string file;
        int w = 10;
        int h = 10;
        public PlayGame(bool isNew, string fileName) {
            
           
            this.Stopwatch = new Stopwatch();
            this.Stopwatch.Start();
            this._timer = new Timer(
                new TimerCallback((s) => this.FirePropertyChanged(this, new PropertyChangedEventArgs("Stopwatch"))),
                null, 1000, 1000);
            //n = new Game(w, h, file);
            //if maze is old make old
            InitializeComponent();

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

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Do you want to save your progress?", "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                n.Save();
               
            }
            else
            {
                // Do not close the window  
            }
        }
        private void Pause_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show(this, "Paused Timer");
            //TODO: actually pause timer
            
        }
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Do you want to close this window?","Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                var MainWin = new MainWindow();
                MainWin.Show();
                this.Close();
            }
            else
            {
                // Do not close the window  
            }
            
        }
    }
}
