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
    /// Interaction logic for HighScores.xaml
    /// </summary>
    public partial class HighScores : Window
    {
        public HighScores()
        {
            InitializeComponent();
            ReadHighScores();
        }
        private void Home_Click(object sender, RoutedEventArgs e)
        {
            var Main = new MainWindow();
            Main.Show();
            this.Close();
        }
        private void ReadHighScores()
        {
            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\loone\source\repos\Maze\Maze\HighScores.txt");
            
            int i = 0;
            foreach (string line in lines)
            {
                string[] player = lines[i].Split(' ');
                Names.Text += player[0] + "\n";
                Scores.Text += player[1] + "\n";
                i++;
            }

        }
    }
}
