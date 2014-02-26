namespace AcademyMaze
{
    using System;
    using System.Linq;

    public class Map
    {
        static char tile = '\u25a0';

        public MapType Type { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public bool[,] WorldMap { get; set; }


        public Map(MapType mapType)
        {
            this.Type = mapType;

            if (this.Type == MapType.Easy)
            {
                this.Width = 9;
                this.Height = 9;
            }
            else if (this.Type == MapType.Medium)
            {
                this.Width = 12;
                this.Height = 12;
            }
            else if (this.Type == MapType.Hard)
            {
                this.Width = 15;
                this.Height = 15;
            }

            this.WorldMap = new bool[this.Width, this.Height];
        }

        public void DrawMap()
        {
            Console.ForegroundColor = ConsoleColor.Gray;

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
