namespace AcademyMaze
{
    using System;

    public class AcademyMazeMain
    {
        public static void Main(string[] args)
        {
            GameMenu.StartMenuPrint();

            Engine engine = new Engine(GameMenu.SelectedPlayerType, new KeyboardInterface());
            engine.Start();
        }
    }
}
