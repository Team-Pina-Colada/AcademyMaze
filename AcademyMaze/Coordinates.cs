namespace AcademyMaze
{
    public struct Coordinates
    {
        public Coordinates(int coordinateX, int coordinateY)
            : this()
        {
            this.CoordinateX = coordinateX;
            this.CoordinateY = coordinateY;
        }

        public int CoordinateX { get; set; }

        public int CoordinateY { get; set; }

        public static bool operator ==(Coordinates first, Coordinates second)
        {
            if (first.CoordinateX == second.CoordinateX && first.CoordinateY == second.CoordinateY)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool operator !=(Coordinates first, Coordinates second)
        {
            if (first == second)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
