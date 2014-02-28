namespace AcademyMaze
{
    using System;
    using AcademyMaze.Interfaces;

    public class Player : WorldObject, IMovable
    {
        public Player(Coordinates initialCoordinates, PlayerType playerType)
            : base(initialCoordinates)
        {
            this.CurrentPosition = initialCoordinates;

            this.HeroType = playerType;

            if (this.HeroType == PlayerType.Stubborn)
            {
                this.Intelligence = 2;
                this.Motivation = 5;
            }

            if (this.HeroType == PlayerType.Nerd)
            {
                this.Intelligence = 4;
                this.Motivation = 3;
            }
        }

        public int Intelligence { get; set; }

        public int Motivation { get; set; }

        public PlayerType HeroType { get; set; }

        public Coordinates CurrentPosition { get; set; }

        public void DrawPlayer()
        {
            Console.SetCursorPosition(this.CurrentPosition.CoordinateY, this.CurrentPosition.CoordinateX);
            Console.Write("X");
        }

        public void MoveLeft()
        {
            this.Move(0, -1);
        }

        public void MoveRight()
        {
            this.Move(0, 1);
        }

        public void MoveUp()
        {
            this.Move(-1, 0);
        }

        public void MoveDown()
        {
            this.Move(1, 0);
        }

        public override string InteractNotification()
        {
            return "I am player, I do not return a sh...";
        }

        private void Move(int x, int y)
        {
            this.CurrentPosition = new Coordinates(this.CurrentPosition.CoordinateX + x, this.CurrentPosition.CoordinateY + y);
        }
    }
}
