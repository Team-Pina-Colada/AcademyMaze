namespace AcademyMaze
{
    public abstract class HandicapEnemy : Enemy
    {
        public HandicapEnemy(Coordinates initialCoordinates, int hitPoints)
            : base(initialCoordinates, hitPoints)
        {
        }
    }
}
