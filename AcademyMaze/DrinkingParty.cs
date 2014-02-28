namespace AcademyMaze
{
    public class DrinkingParty : HandicapEnemy
    {
        private const int InteligenceHandicap = 1;
        private const int MotivationHandicap = 1;

        public DrinkingParty(Coordinates initialCoordinates)
            : base(initialCoordinates, InteligenceHandicap, MotivationHandicap)
        {
        }

        /*
        public void ReduceHeroStats(Player player)
        {
            player.Motivation--;
            player.Intelligence--;
        }
        */

        public override string InteractNotification()
        {
            return "Alcochol is bad! Very bad! You are a drunk pig!\nYour stats decreased.";
        }
    }
}
