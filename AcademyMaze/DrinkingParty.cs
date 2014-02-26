namespace AcademyMaze
{
    using AcademyMaze.Interfaces;

    public class DrinkingParty : HandicapEnemy, ITakeAway
    {
        public DrinkingParty(Coordinates initialCoordinates, int hitPoints)
            : base(initialCoordinates, hitPoints)
        {
        }

        public void ReduceHeroStats(Player player)
        {
            player.Motivation--;
            player.Intelligence--;
        }
    }
}
