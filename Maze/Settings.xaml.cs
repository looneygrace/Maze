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

            
            RedWall.Text = "0";
            BlueWall.Text = "0";
            GreenWall.Text = "0";
            RedFloor.Text = "0";
            GreenFloor.Text = "0";
            BlueFloor.Text = "0";


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
            else
            {
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
                    return x;
                }
            }
        }
    }
}