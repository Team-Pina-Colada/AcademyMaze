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

    }
}
