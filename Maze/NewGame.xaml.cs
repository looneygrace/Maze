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
    /// Interaction logic for NewGame.xaml
    /// </summary>
    public partial class NewGame : Window, INotifyPropertyChanged
    {
        public NewGame()
        {
            InitializeComponent();
            this.Stopwatch = new Stopwatch();
            this.Stopwatch.Start();
            this._timer = new Timer(
                new TimerCallback((s) => this.FirePropertyChanged(this, new PropertyChangedEventArgs("Stopwatch"))),
                null, 1000, 1000);
            Game n = new Game();
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
