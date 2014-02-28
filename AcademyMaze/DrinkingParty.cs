namespace AcademyMaze
{
    using AcademyMaze.Interfaces;

    public class DrinkingParty : HandicapEnemy, ITakeAway
    {
        public DrinkingParty(Coordinates initialCoordinates)
            : base(initialCoordinates)
        {
        }

        public void ReduceHeroStats(Player player)
        {
            player.Motivation--;
            player.Intelligence--;
        }

        public override string InteractNotification()
        {
            return "Alcochol is bad! Very bad! You are a drunk pig!\nYour stats decreased.";
        }
    }
}
