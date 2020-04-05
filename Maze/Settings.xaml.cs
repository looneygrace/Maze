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
    /// Interaction logic for Settings.xaml
    /// </summary>
    public partial class Settings : Window
    {
        public Settings()
        {
            InitializeComponent();

            ColorBox.Fill = bConverter();
        }

        public Brush bConverter()
        {
            string r = Red.Text;
            string b = Blue.Text;
            string g = Green.Text;

            int redInt = int.Parse(r);
            int greenInt = int.Parse(g);
            int blueInt = int.Parse(b);
            if(redInt >= 255)
            {
                redInt = 255;
                Red.Text = "255";
            }
            if (blueInt >= 255)
            {
                blueInt = 255;
                Blue.Text = "255";
            }
            if (greenInt >= 255)
            {
               greenInt = 255;
               Green.Text = "255";
            }
            if(redInt <= 0)
            {
                redInt = 0;
                Red.Text = "0";
            }
            byte red = Convert.ToByte(redInt);
            byte blue = Convert.ToByte(redInt);
            byte green = Convert.ToByte(redInt);

            SolidColorBrush brush = new SolidColorBrush();
            brush.Color = Color.FromRgb(red, green, blue);
            return brush;
        }

        private void Home_Click(object sender, RoutedEventArgs e)
        {
            var Main = new MainWindow();
            Main.Show();
            this.Close();
        }
    }
}
