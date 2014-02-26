namespace AcademyMaze
{
    using System;

    public class ExamOop : Exam
    {
        public ExamOop(Coordinates position, int hitPoints)
            : base(position, hitPoints)
        {
        }

        public override void AskQuestion()
        {
            base.AskQuestion();
        }
    }
}
