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
        private Theme theme;
        CustomTheme ct;
        public Settings()
        {

            InitializeComponent();
            ct = new CustomTheme();
            theme = new Theme();
            theme.updateMusic("NA");
            RedWall.Text = "0";
            BlueWall.Text = "0";
            GreenWall.Text = "0";
            RedFloor.Text = "0";
            GreenFloor.Text = "0";
            BlueFloor.Text = "0";
            MusicFileName = "Nothing";
            sound = new MediaPlayer();
            customSettings();
            //sound.PlayLooping();
        }
        //custom colors
        private void updateBack(string background)
        {
            ImageBrush myBrush = new ImageBrush();
            myBrush.ImageSource =
                new BitmapImage(new Uri(background, UriKind.Relative));
            this.Background = myBrush;
            fl.Opacity = .37;
            theme.updateBackground(background);
        }
        private void customSettings()
        {
            ImageBrush myBrush = new ImageBrush();
            string[] lines = System.IO.File.ReadAllLines("../../Settings.txt");
            theme.updateMusic(lines[1]);
            if (lines[0] == "../../CustomSettings.txt")
            {
                string[] customlines = System.IO.File.ReadAllLines("../../CustomSettings.txt");
                RedWall.Text = customlines[0];
                BlueWall.Text = customlines[1];
                GreenWall.Text = customlines[2];
                RedFloor.Text = customlines[3];

                BlueWall.Text = customlines[4];

                GreenFloor.Text = customlines[5];
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
                theme.updateBackground(lines[0]);
            }
            var uri = new Uri(lines[1], UriKind.Relative);

            sound = new MediaPlayer();
            sound.Open(uri);
            sound.Play();
            SystemSounds.Beep.Play();
        }
        private void Floor_TextChanged(object sender, EventArgs e)
        {

            RedFloor.Text = valueCheck(RedFloor.Text);
            GreenFloor.Text = valueCheck(GreenFloor.Text);
            BlueFloor.Text = valueCheck(BlueFloor.Text);

            SolidColorBrush f = new SolidColorBrush();
            f.Color = Color.FromRgb(Convert.ToByte(RedFloor.Text), Convert.ToByte(BlueFloor.Text), Convert.ToByte(GreenFloor.Text));
            FloorColor.Fill = f;



            if (Custom.IsChecked == true)

            {



                this.Background = WallColor.Fill;



                fl.Fill = f;



            }
        }

        private void Wall_TextChanged(object sender, EventArgs e)
        {
            SolidColorBrush w = new SolidColorBrush();
            RedWall.Text = valueCheck(RedWall.Text);
            GreenWall.Text = valueCheck(GreenWall.Text);
            BlueWall.Text = valueCheck(BlueWall.Text);

            w.Color = Color.FromRgb(Convert.ToByte(RedWall.Text), Convert.ToByte(BlueWall.Text), Convert.ToByte(GreenWall.Text));
            WallColor.Fill = w;



            if (Custom.IsChecked == true)
            {
                this.Background = w;
                
                fl.Fill = WallColor.Fill;
                
            }
        }

        private void Home_Click(object sender, RoutedEventArgs e)
        {
            var Main = new MainWindow();
            //TODO make the setting change universal
            Save_Settings();
            Main.Show();
            sound.Stop();
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
            if (sound != null)
            {
                sound.Stop();
            }
            CreepyMusic.IsChecked = false;
            GardenMusic.IsChecked = false;
            SpaceMusic.IsChecked = false;
            HappyMusic.IsChecked = false;
        }

        private void CreepyMusic_Uncheck(object sender, RoutedEventArgs e)
        {
            if (sound != null)
            {
                sound.Stop();
            }
            CreepyMusic.IsChecked = true;
            NoMusic.IsChecked = false;
            GardenMusic.IsChecked = false;
            HappyMusic.IsChecked = false;
            SpaceMusic.IsChecked = false;
            PlayMusic(sender, e);
        }

        private void GardenMusic_Uncheck(object sender, RoutedEventArgs e)
        {

            if (sound != null)
            {
                sound.Stop();
            }
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

            if (sound != null)
            {
                sound.Stop();
            }
            CreepyMusic.IsChecked = false;
            NoMusic.IsChecked = false;
            GardenMusic.IsChecked = false;
            HappyMusic.IsChecked = true;
            SpaceMusic.IsChecked = false;
            PlayMusic(sender, e);
        }

        private void SpaceMusic_UnCheck(object sender, RoutedEventArgs e)
        {

            if (sound != null)
            {
                sound.Stop();
            }
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
            theme.updateMusic(MusicFileName);
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
            updateBack("../../brick.jpg");
        }

        private void ShrubTheme_Checked(object sender, RoutedEventArgs e)
        {
            Stone.IsChecked = false;
            Brick.IsChecked = false;
            Shrub.IsChecked = true;
            Dungeon.IsChecked = false;
            Custom.IsChecked = false;
            updateBack("../../shrub.jpg");
        }

        private void DungeonTheme_Checked(object sender, RoutedEventArgs e)
        {
            Stone.IsChecked = false;
            Brick.IsChecked = false;
            Shrub.IsChecked = false;
            Dungeon.IsChecked = true;
            Custom.IsChecked = false;
            updateBack("../../dungeon.jpg");
        }

        private void StoneTheme_Checked(object sender, RoutedEventArgs e)
        {
            Stone.IsChecked = true;
            Brick.IsChecked = false;
            Shrub.IsChecked = false;
            Dungeon.IsChecked = false;
            Custom.IsChecked = false;
            updateBack("../../stone.jpg");
        }

        private void CustomTheme_Checked(object sender, RoutedEventArgs e)
        {
            Stone.IsChecked = false;
            Brick.IsChecked = false;
            Shrub.IsChecked = false;
            Dungeon.IsChecked = false;
            Custom.IsChecked = true; 
            updateBack("../../customSettings.txt");



            theme.backgroundFileName = "../../customSettings.txt";
        }
        private void Save_Settings()
        {
            
            string filename = "../../settings.txt";
            string[] lines = { theme.backgroundFileName, theme.musicFileName};
            System.IO.File.WriteAllLines(filename, lines);
            if (Custom.IsChecked == true)



            {



                string customfilename = "../../customsettings.txt";



                string[] customlines = { RedWall.Text, BlueWall.Text, GreenWall.Text, RedFloor.Text, BlueFloor.Text, GreenFloor.Text };



                System.IO.File.WriteAllLines(customfilename, lines);



            }

        }


    }
    public partial class Theme
    {
        public bool brick;
        public bool custom;
        public CustomTheme c;
        public bool stone;
        public bool shrub;
        public bool dungeon;
        public string musicFileName;
        public string backgroundFileName;
        SolidColorBrush w;
        SolidColorBrush f;
        public Theme()
        {
            f = new SolidColorBrush();
            w = new SolidColorBrush();
            f.Color = Colors.Black;
            w.Color = Colors.White;
        }
        public Theme(SolidColorBrush wall, SolidColorBrush floor, string theme)
        {
            w = wall;
            f = floor;
            updateTheme(theme);
        }
        public void updateTheme(string theme)
        {
            bool isGood;
            if(theme == "brick")
            {
                brick = true;
                custom = false;
                stone = false;
                shrub = false;
                dungeon = false;

            }
            else if (theme == "custom")
            {
                brick = true;
                custom = true;
                stone = false;
                shrub = false;
                dungeon = false;
                isGood = c.isBrushGood(w, f);

            }
            if (theme == "stone")
            {
                brick = false;
                custom = false;
                stone = true;
                shrub = false;
                dungeon = false;

            }
            if (theme == "shrub")
            {
                brick = false;
                custom = false;
                stone = false;
                shrub = true;
                dungeon = false;

            }
            if (theme == "dungeon")
            {
                brick = false;
                custom = false;
                stone = false;
                shrub = false;
                dungeon = true;

            }

        }

        public void updateMusic(string musicFile)
        {
            musicFileName = musicFile;
        }
        public void updateBackground(string backfile)
        {
            backgroundFileName = backfile;
        }

    }
    public partial class CustomTheme : Window
    {
        public SolidColorBrush floor;
        public SolidColorBrush wall;

        public void updateFloor(SolidColorBrush f)
        {
            //Check if walls has the same values if it does pop message
            floor = f;
        }

        public void updateWall(SolidColorBrush w)
        {
            //Check if floors have the same values
            wall = w;
        }
        public bool isBrushGood(SolidColorBrush w, SolidColorBrush f)
        {
            bool isGood;
            int redFloorValue = Convert.ToInt32(f.Color.R);
            int blueFloorValue = Convert.ToInt32(f.Color.B);
            int greenFloorValue = Convert.ToInt32(f.Color.G);
            int redWallValue = Convert.ToInt32(w.Color.R);
            int blueWallValue = Convert.ToInt32(w.Color.R);
            int greenWallValue = Convert.ToInt32(w.Color.R);
            if ((redFloorValue - redWallValue) >= 50 || (redWallValue - redFloorValue) >= 50)
            {
                isGood = true;
            }
            else
            {
                isGood = false;
            }
            if ((greenFloorValue - greenWallValue) >= 50 || (greenWallValue - greenFloorValue) >= 50)
            {
                isGood = true;
            }
            else
            {
                isGood = false;
            }
            if ((blueFloorValue - blueWallValue) >= 50 || (blueWallValue - blueFloorValue) >= 50)
            {
                isGood = true;
            }
            else
            {
                isGood = false;
            }
            return isGood;
        }

    }
}