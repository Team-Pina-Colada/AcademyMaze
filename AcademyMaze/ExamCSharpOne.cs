namespace AcademyMaze
{
    using System;

    public class ExamCSharpOne : Exam
    {
        public ExamCSharpOne(Coordinates position, int hitPoints)
            : base(position, hitPoints)
        {
        }

        public override void AskQuestion()
        {
            base.AskQuestion();
        }
    }
}
