using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyMaze
{
    public class Map
    {
        static char tile = '\u25a0'; // block char representation

        public MapType Type { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public Map(MapType mapType)
        {
            this.Type = mapType;

            if (this.Type == MapType.Easy)
            {
                this.Width = 5;
                this.Height = 5;
            }
            else if (this.Type == MapType.Medium)
            {
                this.Width = 10;
                this.Height = 5;
            }
            else if (this.Type == MapType.Hard)
            {
                this.Width = 15;
                this.Height = 10;
            }
        }

        public void DrawMap()
        {
            for (int row = 0; row < this.Height; row++)
            {
                for (int col = 0; col < this.Width; col++)
                {
                    Console.Write(tile);
                }

                Console.WriteLine();
            }
        }
    }
}
