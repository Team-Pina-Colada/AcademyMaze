using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyMaze.Interfaces
{
    public interface IUserInterface
    {
        event EventHandler<DirectionSetEvent> OnUpPressed;
        event EventHandler<DirectionSetEvent> OnDownPressed;
        event EventHandler<DirectionSetEvent> OnLeftPressed;
        event EventHandler<DirectionSetEvent> OnRightPressed;

        void ProcessInput();
    }
}
