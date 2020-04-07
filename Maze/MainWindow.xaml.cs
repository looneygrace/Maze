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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Maze
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }

        private void New_Game_Click(object sender, RoutedEventArgs e)
        {
            var NewGame = new PlayGame(true, "0");
            NewGame.Show();
            this.Close();
        }

        private void Load_Game_Click(object sender, RoutedEventArgs e)
        {
            var LoadGame = new LoadGame();
            LoadGame.Show();
            this.Close();
        }

        private void High_Scores_Click(object sender, RoutedEventArgs e)
        {
            var HighScores = new HighScores();
            HighScores.Show();
            this.Close();
        }

        private void Credits_Click(object sender, RoutedEventArgs e)
        {
            var Credits = new Credits();
            Credits.Show();
            this.Close();
        }

        private void Settings_Click(object sender, RoutedEventArgs e)
        {
            var Settings = new Settings();
            Settings.Show();
            this.Close();
        }
    }
}
