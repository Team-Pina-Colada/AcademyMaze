namespace AcademyMaze
{
    using AcademyMaze.Interfaces;

    public class MutteringGirlfriend : HandicapEnemy, ITakeAway
    {
        public MutteringGirlfriend(Coordinates initialCoordinates)
            : base(initialCoordinates)
        {
        }

        public void ReduceHeroStats(Player player)
        {
            player.Motivation -= 2;
        }

        public override string InteractNotification()
        {
            return "You don't love me anymore!";
        }
    }
}
