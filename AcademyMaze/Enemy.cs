namespace AcademyMaze
{
    public abstract class Enemy : WorldObject
    {
        public Enemy(Coordinates initialCoordinates, int hitPoints)
            : base(initialCoordinates)
        {
            this.HitPoints = hitPoints;
        }

        public int HitPoints { get; set; }
    }
}
