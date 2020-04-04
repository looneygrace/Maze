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

        int score;

        int[,] maze;
        int positionHeight;
        int mazeWidth;
        int mazeHeight;
        string fileName;
        public void Initialize(int w, int h)
        {
            maze = new int[w, h];
            for(int i =0; i < w; i++)
            {
                maze[i, 0] = i + 1;
            }
        }
        public void makeMaze(int exists)
        {
            //pass in a number 
            //if number is b/w 1-3, a maze exists and call the file that holds the maze
            //if number is 0, then maze doesn't exist we create a new maze
            if(exists == 0)
            {
                makeNewMaze();
            }
            else
            {
                makeOldMaze();
            }
        }
        public void makeNewMaze()
        {
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
                // 1 1 1 1 5 5 
                // 1 1 1 5 1 1
            //Source for reading in https://www.c-sharpcorner.com/UploadFile/mahesh/how-to-read-a-text-file-in-C-Sharp/
            using (StreamReader file = new StreamReader(fileName))
            {
                int w = 0;
                int h = 0;
                mazeWidth = int.Parse(file.ReadLine());
                mazeHeight = int.Parse(file.ReadLine());
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
    }
    

}
