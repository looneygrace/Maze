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

            MusicFileName = "NA";
            RedWall.Text = "0";
            BlueWall.Text = "0";
            GreenWall.Text = "0";
            RedFloor.Text = "0";
            GreenFloor.Text = "0";
            BlueFloor.Text = "0";
            MusicFileName = "Nothing";
            sound = new MediaPlayer();
            //sound.PlayLooping();
        }
//custom colors
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
            if (x.Length >= 1)
            {
                if (!Char.IsDigit(x[0]))
                {
                    return "0";
                }
            }
            if (x.Length >= 2)
            {
                if (!Char.IsDigit(x[1]))
                {
                    return "0";
                }
            }
            if (x.Length == 3)
            {
                if (!Char.IsDigit(x[2]))
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
 //Music       
        private void NoMusic_Uncheck(object sender, RoutedEventArgs e)
        {
            CreepyMusic.IsChecked = false;
            GardenMusic.IsChecked = false;
            SpaceMusic.IsChecked = false;
            HappyMusic.IsChecked = false;
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

        //play music
        private void PlayMusic(object sender, RoutedEventArgs e)
        {
            if (MusicFileName != "Nothing")
            {
                sound.Stop();
            }
            if(CreepyMusic.IsChecked == true)
            {
                MusicFileName = "../../../music/CreepyMusic.mp3";
            }
            else if(GardenMusic.IsChecked == true)
            {
                MusicFileName = "../../../music/GardenMusic.mp3";
                //(The Calling - The Lemming Shepherds)
            }
            else if(HappyMusic.IsChecked == true){
                MusicFileName = "../../../music/HappyMusic.wav";
            }
            else if(SpaceMusic.IsChecked == true)
            {
                MusicFileName = "../../../music/SpaceMusic.wav";
            }
            else
            {
                MusicFileName = "Nothing";
                sound.Stop();
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
 
 //themes

        private void BrickTheme_Checked(object sender, RoutedEventArgs e)
        {
            Stone.IsChecked = false;
            Brick.IsChecked = true;
            Shrub.IsChecked = false;
            Dungeon.IsChecked = false;
            Custom.IsChecked = false;
        }

        private void ShrubTheme_Checked(object sender, RoutedEventArgs e)
        {
            Stone.IsChecked = false;
            Brick.IsChecked = false;
            Shrub.IsChecked = true;
            Dungeon.IsChecked = false;
            Custom.IsChecked = false;
        }

        private void DungeonTheme_Checked(object sender, RoutedEventArgs e)
        {
            Stone.IsChecked = false;
            Brick.IsChecked = false;
            Shrub.IsChecked = false;
            Dungeon.IsChecked = true;
            Custom.IsChecked = false;
        }
        private void StoneTheme_Checked(object sender, RoutedEventArgs e)
        {
            Stone.IsChecked = true;
            Brick.IsChecked = false;
            Shrub.IsChecked = false;
            Dungeon.IsChecked = false;
            Custom.IsChecked = false;
        }

        private void CustomTheme_Checked(object sender, RoutedEventArgs e)
        {
            Stone.IsChecked = false;
            Brick.IsChecked = false;
            Shrub.IsChecked = false;
            Dungeon.IsChecked = false;
            Custom.IsChecked = true;
            //TODO: Unselect All
            //TODO: Get Values from custom panel

        }

        
    }
}