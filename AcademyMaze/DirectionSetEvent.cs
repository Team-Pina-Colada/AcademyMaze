namespace AcademyMaze
{
    using System;

    public class DirectionSetEvent : EventArgs
    {
        public DirectionSetEvent(Direction setDirection)
        {
            this.SetDirection = setDirection;
        }

        public Direction SetDirection { get; set; }
    }
}
