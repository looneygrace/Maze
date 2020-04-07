﻿using System;
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
    /// Interaction logic for Settings.xaml
    /// </summary>
    public partial class Settings : Window
    {
        TextBoxColor wall;
        TextBoxColor floor;

        public Settings()
        {

            InitializeComponent();
            wall = new TextBoxColor();
            floor = new TextBoxColor();


            WallColor.Fill = wall.bConverter(RedWall.Text, BlueWall.Text, GreenWall.Text);
            
            FloorColor.Fill = floor.bConverter(RedFloor.Text,BlueFloor.Text, GreenFloor.Text);

        }


        private void Floor_TextChanged(object sender, EventArgs e)
        {
        }
        private void Home_Click(object sender, RoutedEventArgs e)
        {
            var Main = new MainWindow();
            Main.Show();
            this.Close();
        }
        

    }
    public partial class TextBoxColor : Settings
    {
        int red;
        int blue;
        int green;
        public TextBoxColor()
        {
            red = 0;
            blue = 0;
            green = 0;
        }
        public void updateColors(string r, string b, string g)
        {
            int redInt = int.Parse(r);
            int greenInt = int.Parse(g);
            int blueInt = int.Parse(b);
            //Red handler
            if (redInt >= 255)
            {
                redInt = 255;
                r = "255";
            }
            else if (redInt <= 0)
            {
                red = 0;
                r = "0";
            }
            else
            {
                red = redInt;
            }
            if (blueInt >= 255)
            {
                blue = 255;
                b = "255";
            }
            else if (blueInt <= 0)
            {
                blue = 0;
            }
            else
            {
                blue = blueInt;
            }
            if (greenInt >= 255)
            {
                green = 255;
                g = "255";
            }

            
           

        }
        public Brush bConverter(string r, string b, string g)
        {

      

            byte red = Convert.ToByte(r);
            byte blue = Convert.ToByte(b);
            byte green = Convert.ToByte(g);

            SolidColorBrush brush = new SolidColorBrush();
            brush.Color = Color.FromRgb(red, green, blue);
            return brush;
        }
    }
    
}