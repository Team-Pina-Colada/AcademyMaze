using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyMaze.Interfaces
{
    interface IUserInterface
    {
        event EventHandler OnUpPressed;
        event EventHandler OnDownPressed;
        event EventHandler OnLeftPressed;
        event EventHandler OnRightPressed;

        void ProcessInput();
    }
}
