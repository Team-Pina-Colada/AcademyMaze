namespace AcademyMaze
{
    using System;
    using System.Collections.Generic;

    public class ExamCSharpOne : Exam
    {
        private static readonly IList<Question> questions = new List<Question> {
            new Question("Which of these is integer and contains only positive values",
                new List<string>{"int", "double", "byte", "short"},
                2),
            new Question("Which is the default value of char",
                new List<string>{"null", @"\0","0", "none of these"},
                1),
        };

        

        public ExamCSharpOne(Coordinates position)
            : base(position, questions)
        {
            
        }

        public override Question AskQuestion()
        {
            this.currentlyAskedQuestion++;
            return questions[this.currentlyAskedQuestion - 1];
        }

        public override string InteractNotification()
        {
            throw new NotImplementedException();
        }
    }
}
