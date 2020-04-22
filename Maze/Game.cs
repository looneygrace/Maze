using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
using JetBrains.Annotations;
using System.Collections.Generic;
using System.Windows.Documents;
using NPOI.SS.Formula.Functions;
using System.Windows.Forms;

namespace Maze
{
    class Game
    {

        private int score;//the score of the player
        
        int positionHeight, positionWidth;// Where the player starts out

        int mazeWidth, mazeHeight;//the dimensions of the maze

        string fileName;//the name of the file to store it;
        public Game(int w, int h, string file)
        {
            
            if (fileName == "1" || fileName == "2" || fileName == "3")
            {
                //open saved maze
                fileName = file;
                mazeWidth = w;
                mazeHeight = h;
                makeMaze(true);
                displayMaze();
            }
            else if (fileName == "none")
            {
                //make new maze

                fileName = file;
                mazeWidth = w;
                mazeHeight = h;
                setScore(0);
                //Initialize(0);
                makeMaze(false);
                displayMaze();

            }
        }

        private void makeMaze(bool exists)
        {
            //if true, a maze exists and call the file that holds the maze
            //if false, then maze doesn't exist we create a new maze
            if (exists == false)
            {
                //makeNewMaze();
            }
            else
            {
                makeOldMaze();
            }
        }
        private void makeNewMaze(PictureBox x)
        {
            //_grid = new Grid(MazeSize, MazeSize);
        }

        public void makeOldMaze()
        {
            //make a maze container
            //file syntax
            //Width
            //Length
            //position X
            //position Y
            //score
            // 1 1 1 1 5 5 
            // 1 1 1 5 5 6
            //Source: https://www.c-sharpcorner.com/UploadFile/mahesh/how-to-read-a-text-file-in-C-Sharp/
            //TODO: Implement
            using (StreamReader file = new StreamReader(fileName))
            {
                int w = 0;
                int h = 0;

                mazeWidth = int.Parse(file.ReadLine());
                mazeHeight = int.Parse(file.ReadLine());
                positionHeight = int.Parse(file.ReadLine());
                positionWidth = int.Parse(file.ReadLine());
                setScore(int.Parse(file.ReadLine()));
                //maze = new int[mazeWidth, mazeHeight];

                for (h = 0; h < mazeHeight; h++)
                {
                    for (w = 0; w < mazeWidth; w++)
                    {
                        //maze[w, h] = int.Parse(file.ReadLine());
                    }
                }
                file.Close();
            }
            displayMaze();
        }
        public void displayMaze()
        {
            //TODO Implement
            Console.WriteLine("Maze is working");
        }
        private void setScore(int s)
        {
            score = s;
        }

        public void Save(string fileName)
        {
            //TODO: Implement
        }
    }
    

}