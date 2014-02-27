namespace AcademyMaze
{
    using System;
    using AcademyMaze.Interfaces;

    public class AcademyMazeMain
    {
        public static void Main(string[] args)
        {
            GameMenu.StartMenuPrint();
            Engine engine = new Engine(PlayerType.Stubborn, new KeyboardInterface());
            engine.Start();
        }
    }
}
