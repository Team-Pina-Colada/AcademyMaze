namespace AcademyMaze
{
    using System;

    using AcademyMaze.Interfaces;

    public abstract class Exam : Enemy, IAskQuestion, IGiveBonus, IOptionable
    {
        public Exam(Coordinates initialCoordinates, int hitPoints)
            : base(initialCoordinates, hitPoints)
        {
        }

        public virtual void AskQuestion()
        {
            Console.Write("The Exam asks you: ");
        }
    }
}
