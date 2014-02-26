namespace AcademyMaze
{
    public abstract class WorldObject
    {
        public WorldObject(Coordinates initialCoordinates)
        {
            this.StartingPosition = initialCoordinates;
        }

        public Coordinates StartingPosition { get; set; }
    }
}
