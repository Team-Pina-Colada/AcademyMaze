namespace AcademyMaze
{
    using System;
    using System.Linq;

    public class Map
    {
        private static readonly char Tile = '\u25a0';

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

        public MapType Type { get; set; }

        public int Width { get; set; }

        public int Height { get; set; }

        public bool[,] WorldMap { get; set; }

        public void DrawMap()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.SetCursorPosition(0, 0);

            for (int row = 0; row < this.Height; row++)
            {
                for (int col = 0; col < this.Width; col++)
                {
                    if (this.WorldMap[row, col] == true)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }

                    Console.Write(Tile);
                    Console.ForegroundColor = ConsoleColor.Gray;
                }

                Console.WriteLine();
            }
        }
    }
}
