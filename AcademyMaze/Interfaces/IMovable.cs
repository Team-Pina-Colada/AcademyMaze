namespace AcademyMaze.Interfaces
{
    // This interface will be implemented by classes which instances can change their possition (like our player)
    public interface IMovable
    {
        void Move(Coordinates newPosition);
    }
}
