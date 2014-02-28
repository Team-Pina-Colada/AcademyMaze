namespace AcademyMaze
{
    public class MutteringGirlfriend : HandicapEnemy
    {
        private const int InteligenceHandicap = 0;
        private const int MotivationHandicap = 2;

        public MutteringGirlfriend(Coordinates initialCoordinates)
            : base(initialCoordinates, InteligenceHandicap, MotivationHandicap)
        {
        }

        /*
        public void ReduceHeroStats(Player player)
        {
            player.Motivation -= 2;
        }
        */

        public override string InteractNotification()
        {
            return "You don't love me anymore!";
        }
    }
}
