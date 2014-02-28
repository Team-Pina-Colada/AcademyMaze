namespace AcademyMaze
{
    using System;
    using System.Collections.Generic;

    public class ExamOop : Exam
    {
        private const int OopExamHP = 8;
        private const int OopExamAP = 4;
        private const int InteligenceBonus = 5;
        private const int MotivationBonus = 5;

        private static readonly IList<Question> ExamQuestions = new List<Question>
        {
            new Question(
                "To override a method in parent class it should be",
                new List<string> { "Static", "Private", "Abstract", "Interface" },
                2),
            new Question(
                "What is the difference between instance and class",
                new List<string> { "Class represents the blueprint where as instance is an aclual implementation", "Instance is the class declaration", "There is no difference" },
                0),
            new Question(
                "Which interface guarantees foreach",
                new List<string> { "IList", "IEnumerable", "ICollection", "All of them" },
                1),
            new Question(
                "Which of these is NOT from the OOP principles",
                new List<string> { "Encapsulation", "Abstraction", "Inheritance", "Polymorphism", "All of these are OOP principles" },
                4),
            new Question(
                "What is the defaul access modifyer for a class member in C#",
                new List<string> { "ublic", "private", "protected", "internal" },
                3),
        };

        public ExamOop(Coordinates position)
            : base(position, ExamQuestions, OopExamHP, OopExamAP, InteligenceBonus, MotivationBonus)
        {
        }

        public override Question AskQuestion()
        {
            this.CurrentlyAskedQuestion++;
            return this.Questions[this.CurrentlyAskedQuestion - 1];
        }

        public override string InteractNotification()
        {
            return "Congratulations,\nyou have successfuly taken the OOP exam.\nYour stats increased.";
        }
    }
}
