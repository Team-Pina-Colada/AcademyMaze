namespace AcademyMaze
{
    using System;
    using System.Collections.Generic;

    using AcademyMaze.Interfaces;

    public abstract class Exam : Enemy, IAskQuestion, IGiveBonus, IOptionable
    {
        protected int currentlyAskedQuestion;

        public Exam(Coordinates initialCoordinates, ICollection<Question> questions)
            : base(initialCoordinates)
        {
            this.currentlyAskedQuestion = 0;
        }

        public abstract Question AskQuestion();

        public void IncreaseHeroStats(Player player)
        {
            throw new NotImplementedException();
        }

    }
}
