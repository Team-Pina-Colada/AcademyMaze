namespace AcademyMaze
{
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            GameMenu.StartMenuPrint();
            Engine engine = new Engine(PlayerType.Stubborn);
            engine.Start();
        }
    }
}
