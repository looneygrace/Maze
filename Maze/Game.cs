using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;

namespace Maze
{
    class Game
    {

        private int score;

        int[,] maze;
        int positionHeight, positionWidth;
        int mazeWidth, mazeHeight;
        string fileName;
        public Game(int w, int h, string file)
        {            
            if(fileName == "1" || fileName == "2" || fileName == "3")
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
                Initialize(0);
                makeMaze(false);
                displayMaze();

            }
        }
        public void Initialize(int r)
        {
            
            for(int i =0; i < mazeWidth; i++)
            {
                maze[i, r] = i + 1;
            }
        }
        private void makeMaze(bool exists)
        {
            //if true, a maze exists and call the file that holds the maze
            //if false, then maze doesn't exist we create a new maze
            if(exists == false)
            {
                makeNewMaze();
            }
            else
            {
                makeOldMaze();
            }
        }
        private void makeNewMaze()
        {
            //TODO: Assign a start position
            positionWidth = 0;
            //randomly choose wall to merge
            //when merging change number to lowest

            //choose how many walls to destoy
            //choose which walls to destroy
            var rand = new Random();
            int numWallsDestroy = rand.Next(1, mazeWidth - 1);
            int[] walls = new int[mazeWidth + 1];
            for (int i = 1; i < mazeWidth; i++ ) {
                walls[i] = i;
            }


            int d = 0;
            while(d < numWallsDestroy)
            {
                int wall = rand.Next(0, numWallsDestroy);
                //if wall exists remove it
                if (walls.Contains(wall))
                {
                    //remove wall
                    if (wall != 0 && wall != mazeWidth + 1)
                    {//removed wall is not the outside wall
                        walls[wall] = wall - 1;
                        maze[wall,0] = maze[wall - 1,0];
                        d++;
                    }
                    
                }
            }
            //
        }
        public void makeOldMaze()
        {
            //make a maze container
            //file syntax
            //Width
            //Length
            //score
                // 1 1 1 1 5 5 
                // 1 1 1 5 1 1
            //Source for reading in https://www.c-sharpcorner.com/UploadFile/mahesh/how-to-read-a-text-file-in-C-Sharp/
            using (StreamReader file = new StreamReader(fileName))
            {
                int w = 0;
                int h = 0;
                
                mazeWidth = int.Parse(file.ReadLine());
                mazeHeight = int.Parse(file.ReadLine());
                score = int.Parse(file.ReadLine());
                maze = new int[mazeWidth, mazeHeight];

                for(h = 0; h <mazeHeight;h++)
                {
                    for(w = 0; w < mazeWidth; w++)
                    {
                        maze[w,h] = int.Parse(file.ReadLine());
                    }
                }
                file.Close();
            }
            displayMaze();
        }
        public void displayMaze()
        {
            Console.WriteLine("Maze is working");
        }
        private void setScore(int s)
        {
            score = s;
        }
    }
    

}
