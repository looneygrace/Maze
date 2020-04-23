using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
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
            customSettings();
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
        private void customSettings()
        {
            MediaPlayer sound = new MediaPlayer();
            ImageBrush myBrush = new ImageBrush();
            string[] lines = System.IO.File.ReadAllLines("../../Settings.txt");

            if (lines[0] == "../../CustomSettings.txt")
            {
                string[] customlines = System.IO.File.ReadAllLines("../../CustomSettings.txt");
                SolidColorBrush FloorColor = new SolidColorBrush();
                SolidColorBrush WallColor = new SolidColorBrush();
                WallColor.Color = Color.FromRgb(Convert.ToByte(customlines[0]), Convert.ToByte(customlines[2]), Convert.ToByte(customlines[3]));
                FloorColor.Color = Color.FromRgb(Convert.ToByte(customlines[3]), Convert.ToByte(customlines[5]), Convert.ToByte(customlines[4]));
                this.Background = WallColor;
                fl.Fill = FloorColor;
            }
            else
            {
                myBrush.ImageSource =
                    new BitmapImage(new Uri(lines[0], UriKind.Relative));
                this.Background = myBrush;
                fl.Opacity = .37;
            }
            var uri = new Uri(lines[1], UriKind.Relative);

            sound = new MediaPlayer();
            sound.Open(uri);
            sound.Play();
            SystemSounds.Beep.Play();
        }
    }
}
