namespace AcademyMaze
{
    using System;
    using System.Collections.Generic;

    public class ExamCSharpOne : Exam
    {
        private const int CSharpOneHP = 4;
        private const int CSharpOneAP = 1;
        private const int InteligenceBonus = 3;
        private const int MotivationBonus = 3;

        private static readonly IList<Question> ExamQuestions = new List<Question>
        {
            new Question(
                "Which of these is integer and contains only positive values",
                new List<string> { "int", "double", "byte", "short" },
                2),
            new Question(
                "Which is the default value of char",
                new List<string> { "null", @"\0", "0", "none of these" },
                1),
            new Question(
                "Which of these can cause infinite loop",
                new List<string> { "if-else", "while", "foreach", "for" },
                1),
            new Question(
                "Which is the default value of boolean type",
                new List<string> { "false", "null", "0", "true" },
                0),
            new Question(
                "Which type will you use if you calculate money",
                new List<string> { "double", "int", "float", "decimal" },
                3),
        };

        public ExamCSharpOne(Coordinates position)
            : base(position, ExamQuestions, CSharpOneHP, CSharpOneAP, InteligenceBonus, MotivationBonus)
        {
            this.Name = "C#1 exam.";
        }

        public override Question AskQuestion()
        {
            this.CurrentlyAskedQuestion++;
            return this.Questions[this.CurrentlyAskedQuestion - 1];
        }

        public override string InteractNotification()
        {
            return "Congratulations,\nyou have successfuly taken the C# 1 exam.\nYour stats increased.";
        }
    }
}
