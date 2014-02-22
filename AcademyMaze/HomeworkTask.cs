namespace AcademyMaze
{
    using AcademyMaze.Interfaces;

    public class HomeworkTask : Enemy, IAskQuestion, IGiveBonus
    {
        private const int HomeworkHitpoints = 1;

        public HomeworkTask(Coordinates initialCoordinates, int hitPoints)
            : base(initialCoordinates, hitPoints = HomeworkHitpoints)
        {
        }

        public void AskQuestion()
        {
            throw new System.NotImplementedException();
        }
    }
}
