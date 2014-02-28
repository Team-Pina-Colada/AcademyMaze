namespace AcademyMaze
{
    using AcademyMaze.Interfaces;

    public abstract class HandicapEnemy : Enemy, ITakeAway
    {
        private readonly int inteligenceHandicap;
        private readonly int motivationHandicap;

        public HandicapEnemy(Coordinates initialCoordinates, int inteligenceHandicap, int motivationHandicap)
            : base(initialCoordinates)
        {
            this.inteligenceHandicap = inteligenceHandicap;
            this.motivationHandicap = motivationHandicap;
        }

        public void ReduceHeroStats(Player player)
        {
            player.Intelligence -= this.inteligenceHandicap;
            player.Motivation -= this.motivationHandicap;
        }
    }
}
