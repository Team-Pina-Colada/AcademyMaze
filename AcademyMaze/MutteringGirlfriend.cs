namespace AcademyMaze
{
    using AcademyMaze.Interfaces;

    public class MutteringGirlfriend : HandicapEnemy, ITakeAway
    {
        public MutteringGirlfriend(Coordinates initialCoordinates, int hitPoints)
            : base(initialCoordinates, hitPoints)
        {
        }

        public void ReduceHeroStats(Player player)
        {
            player.Motivation -= 2;
        }
    }
}
