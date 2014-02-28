namespace AcademyMaze.Interfaces
{
    using System;
    using System.Linq;

    public interface IUserInterface
    {
        event EventHandler<DirectionSetEvent> OnUpPressed;

        event EventHandler<DirectionSetEvent> OnDownPressed;

        event EventHandler<DirectionSetEvent> OnLeftPressed;

        event EventHandler<DirectionSetEvent> OnRightPressed;

        void ProcessInput();
    }
}
