namespace AcademyMaze
{
    using AcademyMaze.Interfaces;

    public class MutteringGirlfriend : HandicapEnemy, ITakeAway
    {
        public MutteringGirlfriend(Coordinates initialCoordinates, int hitPoints)
            : base(initialCoordinates, hitPoints)
        {
        }
    }
}
