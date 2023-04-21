using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MazeGenerator
{
    internal class PrimMaze
    {
        readonly char PASSAGE_CHAR = '░';
        readonly char WALL_CHAR = '▓';
        readonly bool WALL = false;
        readonly bool PASSAGE = true;
        private int _seed;

        int startingX;
        int startingY;
        decimal wallSize;
        decimal passageSize;
        int xChangeGeneration;
        int yChangeGeneration;
        public List<string> objectNames;
        string wallObjectName;
        

        int height;
        int width;
        bool[,] map;

        public PrimMaze(
            int width,
            int height,
            int startingX,
            int startingY,
            decimal wallSize,
            decimal passageSize,
            int xChangeGeneration,
            int yChangeGeneration,
            List<string> objectNames,
            string wallObjectName
            )
        {
            this.height = height;
            this.width = width;
            this.map = new bool[width, height];
            this.startingX = startingX;
            this.startingY = startingY;
            this.wallSize = wallSize;
            this.passageSize = passageSize;
            this.xChangeGeneration = xChangeGeneration;
            this.yChangeGeneration = yChangeGeneration;
            this.objectNames = objectNames;
            this.wallObjectName = wallObjectName;
            this._seed = Guid.NewGuid().GetHashCode();
        }

        public void Solve()
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

                for(int x = 0; x < width; x += 1)
                {
                    maze += map[x, y] == WALL ? WALL_CHAR : PASSAGE_CHAR;
                }

                maze += WALL_CHAR;
                maze += '\n';
            }

            for(int x = 0; x < width + 2; x += 1)
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

        public string objectGeneration()
        {
            string maze = this.ToString();
            string objectFile = "";
            int incrementX = 0;
            int[] rotations = new int[] { 0, 90, 180, 270 };
            Random random = new Random(this._seed);

            using (StringReader reader = new StringReader(maze))
            {
                string line;
                int i = 0;
                

                while ((line = reader.ReadLine()) != null)
                {
                    int incrementY = 0;

                    if (i == 0 || i == height + 1)
                    {
                        foreach (char c in line)
                        {
                            if(c == WALL_CHAR)
                            {
                                objectFile += $"SpawnObject( \"{this.wallObjectName}\", \"{this.startingX + incrementX}.000000 {this.wallSize.ToString().Replace(",", ".")} {this.startingY + incrementY}.000000\", \"0.000000 0.000000 0.000000\" );\n";
                            }
                            else
                            {
                                string obj = objectNames[random.Next(objectNames.Count)];
                                objectFile += $"SpawnObject( \"{obj}\", \"{this.startingX + incrementX}.000000 {this.passageSize.ToString().Replace(",", ".")} {this.startingY + incrementY}.000000\", \"0.000000 0.000000 0.000000\" );\n";

                            }
                            incrementY += yChangeGeneration;
                        }
                    }
                    else
                    {
                        int j = 0;
                        foreach (char c in line)
                        {
                            if (j == 0 || j == width + 1)
                            {
                                objectFile += $"SpawnObject( \"{this.wallObjectName}\", \"{this.startingX + incrementX}.000000 {this.wallSize.ToString().Replace(",", ".")} {this.startingY + incrementY}.000000\", \"0.000000 0.000000 0.000000\" );\n";
                            }
                            else
                            {
                                string obj = objectNames[random.Next(objectNames.Count)];
                                int rotationX = rotations[random.Next(rotations.Length)];

                                if (c == WALL_CHAR)
                                {
                                    objectFile += $"SpawnObject( \"{obj}\", \"{this.startingX + incrementX}.000000 {this.wallSize.ToString().Replace(",", ".")} {this.startingY + incrementY}.000000\", \"{rotationX}.000000 0.000000 0.000000\" );\n";
                                }
                                else
                                {
                                    objectFile += $"SpawnObject( \"{obj}\", \"{this.startingX + incrementX}.000000 {this.passageSize.ToString().Replace(",", ".")} {this.startingY + incrementY}.000000\", \"{rotationX}.000000 0.000000 0.000000\" );\n";
                                }
                            }

                            incrementY += yChangeGeneration;
                            j += 1;
                        }
                    }

                   

                    incrementX += xChangeGeneration;
                    i += 1;
                }
            };

            return objectFile;
        }
    }
}
