using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeGenerator.Maze
{
    public class Maze
    {
        readonly protected char PASSAGE_CHAR = '░';
        readonly protected char WALL_CHAR = '▓';
        readonly protected bool WALL = false;
        readonly protected bool PASSAGE = true;
        private protected int _seed;

        public virtual void Solve() {}
    }
}
