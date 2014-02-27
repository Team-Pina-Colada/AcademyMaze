namespace AcademyMaze
{
    using AcademyMaze.Interfaces;

    public class HomeworkTask : Enemy, IAskQuestion, IGiveBonus
    {
        private const int HomeworkHitpoints = 1;

        public HomeworkTask(Coordinates initialCoordinates)
            : base(initialCoordinates)
        {
            this.HitPoints = HomeworkHitpoints;
        }

        public Question AskQuestion()
        {
            throw new System.NotImplementedException();
        }

        public void IncreaseHeroStats(Player player)
        {
            throw new System.NotImplementedException();
        }

        public override string InteractNotification()
        {
            throw new System.NotImplementedException();
        }
    }
}
