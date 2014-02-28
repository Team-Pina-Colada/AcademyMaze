namespace AcademyMaze
{
    using System;
    using System.Collections.Generic;
    using AcademyMaze.Interfaces;

    public abstract class Exam : Enemy, IAskQuestion, IGiveBonus, IOptionable
    {
        private readonly int inteligenceBonus;
        private readonly int motivationBonus;

        public Exam(Coordinates initialCoordinates, IList<Question> questions, int hitPoints, int attackPoints, int inteligenceBonus, int motivationBonus)
            : base(initialCoordinates)
        {
            this.CurrentlyAskedQuestion = 0;
            this.Questions = questions;
            this.HitPoints = hitPoints;
            this.AttackPoints = attackPoints;
            this.inteligenceBonus = inteligenceBonus;
            this.motivationBonus = motivationBonus;
        }

        public int CurrentlyAskedQuestion { get; protected set; }

        public int HitPoints { get; set; }

        public int AttackPoints { get; protected set; }

        public int TotalQUestions
        {
            get { return this.Questions.Count; }
        }

        public string Name { get; protected set; }

        protected IList<Question> Questions { get; set; }

        public abstract Question AskQuestion();

        public void IncreaseHeroStats(Player player)
        {
            player.Intelligence += this.inteligenceBonus;
            player.Motivation += this.motivationBonus;
        }
    }
}
