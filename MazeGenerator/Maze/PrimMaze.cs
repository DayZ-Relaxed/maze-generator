using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MazeGenerator.Maze
{
    public class PrimMaze : Maze
    {
        protected int height;
        protected int width;
        protected bool[,] map;

        public PrimMaze(
            int width,
            int height
            )
        {
            this.height = height;
            this.width = width;
            this.map = new bool[width, height];
            this._seed = Guid.NewGuid().GetHashCode();
        }

        override public void Solve()
        {
            while (!Validate())
            {
                this._seed = Guid.NewGuid().GetHashCode();
                this.map = new bool[width, height];
                List<int[]> frontiers = new List<int[]>();
                Random random = new Random(this._seed);

                int x = random.Next(0, width);
                int y = random.Next(0, height);
                frontiers.Add(new int[] { x, y, x, y });

                while (frontiers.Count != 0)
                {
                    int removedAt = random.Next(frontiers.Count());
                    int[] frontier = frontiers[removedAt];
                    frontiers.RemoveAt(removedAt);

                    x = frontier[2];
                    y = frontier[3];

                    if (map[x, y] == WALL)
                    {
                        map[frontier[0], frontier[1]] = map[x, y] = PASSAGE;

                        if (x >= 2 && map[x - 2, y] == WALL)
                        {
                            frontiers.Add(new int[] { x - 1, y, x - 2, y });
                        }

                        if (y >= 2 && map[x, y - 2] == WALL)
                        {
                            frontiers.Add(new int[] { x, y - 1, x, y - 2 });
                        }

                        if (x < width - 2 && map[x + 2, y] == WALL)
                        {
                            frontiers.Add(new int[] { x + 1, y, x + 2, y });
                        }

                        if (y < height - 2 && map[x, y + 2] == WALL)
                        {
                            frontiers.Add(new int[] { x, y + 1, x, y + 2 });
                        }
                    }
                }
            }
        }

        private bool Validate()
        {
            int startingX = width / 2;

            if (map[startingX, height - 1] == WALL)
            {
                return false;
            }

            if (map[startingX, height - 2] == WALL)
            {
                return false;
            }

            return true;
        }

        public override string ToString()
        {
            string maze = "";

            for (int x = 0; x < width + 2; x += 1)
            {
                maze += WALL_CHAR;
            }

            maze += '\n';


            for (int y = 0; y < height; y += 1)
            {
                maze += WALL_CHAR;

                for (int x = 0; x < width; x += 1)
                {
                    maze += map[x, y] == WALL ? WALL_CHAR : PASSAGE_CHAR;
                }

                maze += WALL_CHAR;
                maze += '\n';
            }

            for (int x = 0; x < width + 2; x += 1)
            {
                if ((width + 2) / 2 == x)
                {
                    maze += PASSAGE_CHAR;
                }
                else
                {
                    maze += WALL_CHAR;
                }
            }

            maze += '\n';

            return maze.ToString();
        }
    }
}
