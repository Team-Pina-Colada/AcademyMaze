namespace AcademyMaze
{
    using System;
    using System.Linq;
    using AcademyMaze.Interfaces;

    public class KeyboardInterface : IUserInterface
    {
        public event EventHandler<DirectionSetEvent> OnUpPressed;

        public event EventHandler<DirectionSetEvent> OnDownPressed;

        public event EventHandler<DirectionSetEvent> OnLeftPressed;

        public event EventHandler<DirectionSetEvent> OnRightPressed;

        public void ProcessInput()
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);

            if (keyInfo.Key.Equals(ConsoleKey.W) || keyInfo.Key.Equals(ConsoleKey.UpArrow))
            {
                if (this.OnUpPressed != null)
                {
                    this.OnUpPressed(this, new DirectionSetEvent(Direction.Up));
                }
            }

            if (keyInfo.Key.Equals(ConsoleKey.S) || keyInfo.Key.Equals(ConsoleKey.DownArrow))
            {
                if (this.OnDownPressed != null)
                {
                    this.OnDownPressed(this, new DirectionSetEvent(Direction.Down));
                }
            }

            if (keyInfo.Key.Equals(ConsoleKey.A) || keyInfo.Key.Equals(ConsoleKey.LeftArrow))
            {
                if (this.OnLeftPressed != null)
                {
                    this.OnLeftPressed(this, new DirectionSetEvent(Direction.Left));
                }
            }

            if (keyInfo.Key.Equals(ConsoleKey.D) || keyInfo.Key.Equals(ConsoleKey.RightArrow))
            {
                if (this.OnRightPressed != null)
                {
                    this.OnRightPressed(this, new DirectionSetEvent(Direction.Right));
                }
            }
        }
    }
}
