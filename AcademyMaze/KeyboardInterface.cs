namespace AcademyMaze
{
    using System;
    using System.Linq;

    using AcademyMaze.Interfaces;
    public class KeyboardInterface : IUserInterface
    {
        public void ProcessInput()
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey();

                if (keyInfo.Key.Equals(ConsoleKey.W) || keyInfo.Key.Equals(ConsoleKey.UpArrow))
                {
                    if (this.OnUpPressed != null)
                    {
                        this.OnUpPressed(this, new EventArgs());
                    }
                }

                if (keyInfo.Key.Equals(ConsoleKey.S) || keyInfo.Key.Equals(ConsoleKey.DownArrow))
                {
                    if (this.OnDownPressed != null)
                    {
                        this.OnDownPressed(this, new EventArgs());
                    }
                }

                if (keyInfo.Key.Equals(ConsoleKey.A) || keyInfo.Key.Equals(ConsoleKey.LeftArrow))
                {
                    if (this.OnLeftPressed != null)
                    {
                        this.OnLeftPressed(this, new EventArgs());
                    }
                }

                if (keyInfo.Key.Equals(ConsoleKey.D) || keyInfo.Key.Equals(ConsoleKey.RightArrow))
                {
                    if (this.OnRightPressed != null)
                    {
                        this.OnRightPressed(this, new EventArgs());
                    }
                }

            }
        }

        public event EventHandler OnUpPressed;

        public event EventHandler OnDownPressed;

        public event EventHandler OnLeftPressed;

        public event EventHandler OnRightPressed;
    }
}
