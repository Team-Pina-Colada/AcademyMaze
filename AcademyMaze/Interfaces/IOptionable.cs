namespace AcademyMaze.Interfaces
{
    // This interface will be implemented by classes which instances can be "skipped" during the game (i.e. the exam enemy. If IOptionalble a question will be asked if the player wants to visit this field on the map uppon stepping on it
    public interface IOptionable
    {
        string Name { get; }
    }
}
