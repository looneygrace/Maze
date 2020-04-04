using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace Maze
{
    class Game
    {

        int score;

        int[,] maze;
        int positionHeight;
        int mazeWidth;
        int mazeHeight;
        string file;
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
        }
        public void makeNewMaze()
        {

        }
        public void makeOldMaze()
        {

        }

    }
    

}
