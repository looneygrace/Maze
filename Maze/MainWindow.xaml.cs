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
            customSettings();
        }

        private void New_Game_Click(object sender, RoutedEventArgs e)
        {
            MazeForm NewGame = new MazeForm();
            NewGame.Show();
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
        private void customSettings()
        {

            string[] lines = System.IO.File.ReadAllLines("../../Settings.txt");

            if (lines[0] == "../../CustomSettings.txt")
            {
                //custom = true;
                string[] customlines = System.IO.File.ReadAllLines("../../CustomSettings.txt");
                Console.Write("CUSTOM");
                SolidColorBrush FloorColor = new SolidColorBrush();
                SolidColorBrush WallColor = new SolidColorBrush();
                WallColor.Color = Color.FromRgb(Convert.ToByte(customlines[0]), Convert.ToByte(customlines[2]), Convert.ToByte(customlines[3]));
                FloorColor.Color = Color.FromRgb(Convert.ToByte(customlines[3]), Convert.ToByte(customlines[5]), Convert.ToByte(customlines[4]));

                this.Background = WallColor;
                //fl.Fill = FloorColor;

            }
            else
            {
                ImageBrush myBrush = new ImageBrush();
                myBrush.ImageSource =
                    new BitmapImage(new Uri(lines[0], UriKind.Relative));
                this.Background = myBrush;
                //fl.Opacity = .35;
            }

            MediaPlayer sound;
            var uri = new Uri(lines[1], UriKind.Relative);

            sound = new MediaPlayer();

            sound.Open(uri);

            sound.Play();
            SystemSounds.Beep.Play();
            Console.WriteLine(lines[1]);
        }
    }
}
