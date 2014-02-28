namespace AcademyMaze
{
    using System.Collections.Generic;

    public class ExamCSharpTwo : Exam
    {
        private const int CSharpTwoHP = 5;
        private const int CSharpTwoAP = 3;
        private const int InteligenceBonus = 4;
        private const int MotivationBonus = 4;

        private static readonly IList<Question> ExamQuestions = new List<Question>
        {
            new Question(
                "Which of these is incorrect",
                new List<string> { "Array.Count", "Array.Clear", "Array.Copy", "Array.Sort" },
                0),
            new Question(
                "Stream Reader and Stream Writer are in",
                new List<string> { "System.Colections", "System.Linq", "System.IO", "System.Exception" },
                2),
            new Question(
                "What does .Substring(5, 8) return",
                new List<string> { "String of 5 symbols, starting from the 8th", "String of 8 symbols, starting from the 5th", "The string from 5th to 8th symbol", "Five eights" },
                1),
            new Question(
                "The .Append method belongs to",
                new List<string> { "List", "String", "StringBuilder", "Array" },
                2),
            new Question(
                "Which of these does not have indexator",
                new List<string> { "List", "Array", "String", "Steak", "All have indexators" },
                3),
        };

        public ExamCSharpTwo(Coordinates position)
            : base(position, ExamQuestions, CSharpTwoHP, CSharpTwoAP, InteligenceBonus, MotivationBonus)
        {
        }

        public override Question AskQuestion()
        {
            this.CurrentlyAskedQuestion++;
            return this.Questions[this.CurrentlyAskedQuestion - 1];
        }

        public override string InteractNotification()
        {
            return "Congratulations,\nyou have successfuly taken the C# 2 exam.\nYour stats increased.";
        }
    }
}
