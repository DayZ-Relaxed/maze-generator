using MazeGenerator.Maze;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeGenerator.DayZ
{
    internal class DayZRelaxedMazeHelpers : PrimMaze
    {
        private int startingX;
        private int startingY;
        private decimal wallSize;
        private decimal passageSize;
        private int xChangeGeneration;
        private int yChangeGeneration;
        public List<string> objectNames;
        private string wallObjectName;

        public DayZRelaxedMazeHelpers(
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
            ) : base(width, height)
        {
            this.startingX = startingX;
            this.startingY = startingY;
            this.wallSize = wallSize;
            this.passageSize = passageSize;
            this.xChangeGeneration = xChangeGeneration;
            this.yChangeGeneration = yChangeGeneration;
            this.objectNames = objectNames;
            this.wallObjectName = wallObjectName;
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
                            if (c == WALL_CHAR)
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
