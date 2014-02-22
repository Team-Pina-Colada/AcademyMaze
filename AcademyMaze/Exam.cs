namespace AcademyMaze
{
    using AcademyMaze.Interfaces;

    public class Exam : Enemy, IAskQuestion, IGiveBonus, IOptionable
    {
        public Exam(Coordinates initialCoordinates, int hitPoints)
            : base(initialCoordinates, hitPoints)
        {
        }

        public void AskQuestion()
        {
            throw new System.NotImplementedException();
        }
    }
}
