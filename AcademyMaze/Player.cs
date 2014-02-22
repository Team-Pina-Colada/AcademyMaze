namespace AcademyMaze
{
    using AcademyMaze.Interfaces;

    public class Player : WorldObject, IMovable
    {
        public Player(Coordinates initialCoordinates, PlayerType playerType)
            : base(initialCoordinates)
        {
            this.HeroType = playerType;

            // TODO: Implement values for hero stats.
            if (this.HeroType == PlayerType.Stubborn)
            {
                this.Intelligence = 0;
                this.Stubborness = 0;
            }

            if (this.HeroType == PlayerType.Nerd)
            {
                this.Intelligence = 0;
                this.Stubborness = 0;
            }
        }

        public int Intelligence { get; set; }

        public int Stubborness { get; set; }

        public PlayerType HeroType { get; set; }

        public void Move(Coordinates newPosition)
        {
            throw new System.NotImplementedException();
        }
    }
}
