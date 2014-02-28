namespace AcademyMaze
{
    public abstract class Enemy : WorldObject
    {
        public Enemy(Coordinates initialCoordinates)
            : base(initialCoordinates)
        {
        }
    }
}
