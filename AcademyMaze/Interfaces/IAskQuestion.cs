namespace AcademyMaze.Interfaces
{
    // This interface will be implemented by classes which instances can ask questions (enemies like exams and homeworks)
    public interface IAskQuestion
    {
        Question AskQuestion();
    }
}
