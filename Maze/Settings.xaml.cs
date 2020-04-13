using Microsoft.Win32;
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
    /// Interaction logic for Settings.xaml
    /// </summary>
    public partial class Settings : Window
    {
        private string MusicFileName;
        private MediaPlayer sound;
        
        public Settings()
        {

            InitializeComponent();

            MusicFileName = "Nothing";
            RedWall.Text = "0";
            BlueWall.Text = "0";
            GreenWall.Text = "0";
            RedFloor.Text = "0";
            GreenFloor.Text = "0";
            BlueFloor.Text = "0";
            //sound.PlayLooping();
        }

        private void Floor_TextChanged(object sender, EventArgs e)
        {

            RedFloor.Text = valueCheck(RedFloor.Text);
            GreenFloor.Text = valueCheck(GreenFloor.Text);
            BlueFloor.Text = valueCheck(BlueFloor.Text);

            SolidColorBrush f = new SolidColorBrush();
            f.Color = Color.FromRgb(Convert.ToByte(RedFloor.Text), Convert.ToByte(BlueFloor.Text), Convert.ToByte(GreenFloor.Text));
            FloorColor.Fill = f;
        }

        private void Wall_TextChanged(object sender, EventArgs e)
        {
            SolidColorBrush w = new SolidColorBrush();
            RedWall.Text = valueCheck(RedWall.Text);
            GreenWall.Text = valueCheck(GreenWall.Text);
            BlueWall.Text = valueCheck(BlueWall.Text);

            w.Color = Color.FromRgb(Convert.ToByte(RedWall.Text), Convert.ToByte(BlueWall.Text), Convert.ToByte(GreenWall.Text));

            WallColor.Fill = w;
        }

        private void Home_Click(object sender, RoutedEventArgs e)
        {
            var Main = new MainWindow();
            //TODO make the setting change universal
            
            Main.Show();
            this.Close();
        }

        private void UpdateFloor_Click(object sender, RoutedEventArgs e)
        {
            Floor_TextChanged(sender, e);
        }

        private void UpdateWall_Click(object sender, RoutedEventArgs e)
        {
            Wall_TextChanged(sender, e);
        }

        private string valueCheck(string x)
        {
            if (!Char.IsDigit(x[0]) || !Char.IsDigit(x[1]) || !Char.IsDigit(x[2]))
            {
                return "0";
            }
            if(x.Length >= 1)
            {
                if (!Char.IsDigit(x[0]))
                {
                    return "0";
                }
            }
            if(x.Length >= 2)
            {
                if (!Char.IsDigit(x[1]))
                {
                    return "0";
                }
            }
            if(x.Length == 3)
            {
                if(!Char.IsDigit(x[2]))
                {
                    return "0";
                }
            }
            if (int.Parse(x) < 0)
                {
                    return "0";
                }
            else if (int.Parse(x) > 255)
                {
                    return "255";
                }
            else
                {
                    return Convert.ToString(int.Parse(x));
                }
            }        
        private void NoMusic_Uncheck(object sender, RoutedEventArgs e)
        {
            CreepyMusic.IsChecked = false;
            GardenMusic.IsChecked = false;
            SpaceMusic.IsChecked = false;
            HappyMusic.IsChecked = false;
            //sound.Stop();

        }

        private void CreepyMusic_Uncheck(object sender, RoutedEventArgs e)
        {
            CreepyMusic.IsChecked = true;
            NoMusic.IsChecked = false;
            GardenMusic.IsChecked = false;
            HappyMusic.IsChecked = false;
            SpaceMusic.IsChecked = false;
            PlayMusic(sender, e);
        }

        private void GardenMusic_Uncheck(object sender, RoutedEventArgs e)
        {
            CreepyMusic.IsChecked = false;
            NoMusic.IsChecked = false;
            GardenMusic.IsChecked = true;
            HappyMusic.IsChecked = false;
            SpaceMusic.IsChecked = false;
            MusicFileName = "Nothing";
            PlayMusic(sender, e);
        }

        private void HappyMusic_Uncheck(object sender, RoutedEventArgs e)
        {
            CreepyMusic.IsChecked = false;
            NoMusic.IsChecked = false;
            GardenMusic.IsChecked = false;
            HappyMusic.IsChecked = true;
            SpaceMusic.IsChecked = false;
            PlayMusic(sender, e);
        }

        private void SpaceMusic_UnCheck(object sender, RoutedEventArgs e)
        {
            CreepyMusic.IsChecked = false;
            NoMusic.IsChecked = false;
            GardenMusic.IsChecked = false;
            SpaceMusic.IsChecked = true;
            HappyMusic.IsChecked = false;
            PlayMusic(sender, e);
        }
        private void PlayMusic(object sender, RoutedEventArgs e)
        {
            if (MusicFileName != "Nothing")
            {
                sound.Stop();
            }
            if(CreepyMusic.IsChecked == true)
            {
                MusicFileName = "C:/Users/loone/source/repos/Maze/Maze/obj/Debug/music/CreepyMusic.mp3";
            }
            else if(GardenMusic.IsChecked == true)
            {
                MusicFileName = "C:/Users/loone/source/repos/Maze/Maze/obj/Debug/music/GardenMusic.mp3";
                //(The Calling - The Lemming Shepherds)
            }
            else if(HappyMusic.IsChecked == true){
                MusicFileName = "C:/Users/loone/source/repos/Maze/Maze/obj/Debug/music/HappyMusic.wav";
            }
            else if(SpaceMusic.IsChecked == true)
            {
                MusicFileName = "C:/Users/loone/source/repos/Maze/Maze/obj/Debug/music/SpaceMusic.wav";
            }
            else
            {
                MusicFileName = "Nothing";
            }
            var uri = new Uri(MusicFileName, UriKind.Relative);
            
            sound = new MediaPlayer();

            sound.Open(uri);
            sound.Play();
            SystemSounds.Beep.Play();
            Console.WriteLine(MusicFileName);
        }
        // Change the volume of the media.
        private void ChangeMediaVolume(object sender, RoutedPropertyChangedEventArgs<double> args)
        {

        }

        
    }
}