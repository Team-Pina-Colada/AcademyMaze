namespace AcademyMaze
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Map someMap = new Map(MapType.Hard);

            someMap.DrawMap();
        }
    }
}
