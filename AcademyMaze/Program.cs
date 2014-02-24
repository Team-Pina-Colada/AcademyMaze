namespace AcademyMaze
{
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            GameMenu.StartMenuPrint();

            Map someMap = new Map(MapType.Hard);
            someMap.DrawMap();
        }
    }
}
