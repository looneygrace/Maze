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

namespace Maze
{
    /// <summary>
    /// Interaction logic for LoadGame.xaml
    /// </summary>
    public partial class LoadGame : Window
    {
        PlayGame game;
        public LoadGame()
        {
            InitializeComponent();
        }
        private void Home_Click(object sender, RoutedEventArgs e)
        {
            var Main = new MainWindow();
            Main.Show();
            this.Close();
        }
        private void Game1(object sender, RoutedEventArgs e)
        {
            game = new PlayGame(false, "1");
            game.Show();
            this.Close();
        }
        private void Game2(object sender, RoutedEventArgs e)
        {
            game = new PlayGame(false, "2");
            game.Show();
            this.Close();
        }

        private void Game3(object sender, RoutedEventArgs e)
        {
            game = new PlayGame(false, "3");
            game.Show();
            this.Close();
        }
    }
}
