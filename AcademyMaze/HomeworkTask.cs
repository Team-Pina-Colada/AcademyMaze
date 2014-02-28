namespace AcademyMaze
{
    using System;
    using System.Collections.Generic;
    using AcademyMaze.Interfaces;

    public class HomeworkTask : Enemy, IAskQuestion, IGiveBonus
    {
        private readonly List<Question> allQuestions = new List<Question>
        {
            new Question(
                "The array arr[6]{1, 2, 3, 2, 3, 1} is",
                new List<string> { "Symmetric", "Asymmetric" },
                1),
            new Question(
                "You are given array arr[5]{2, 4, 23, 8, 6}. What is the value of arr[2]",
                new List<string> { "2", "23", "4", "8", "6" },
                1),
            new Question(
                "Can you inherit abstract class",
                new List<string> { "Yes", "No" },
                0),
            new Question(
                "Can you modify protected field from chil classes",
                new List<string> { "No", "Yes", "Only if it is static" },
                1),
            new Question(
                "Are the methods implemented in the interfaces",
                new List<string> { "Yes", "No", "It depends" },
                0),
            new Question(
                "Is it obligatory to override virtual methods in child classes",
                new List<string> { "Yes", "No", "It depends" },
                1),
        };

        public HomeworkTask(Coordinates initialCoordinates)
            : base(initialCoordinates)
        {
        }

        public Question AskQuestion()
        {
            Random rand = new Random();
            return this.allQuestions[rand.Next(this.allQuestions.Count)];
        }

        public void IncreaseHeroStats(Player player)
        {
            player.Intelligence++;
        }

        public override string InteractNotification()
        {
            return "You submitted your homework in time.\nGJ, your inteligence increased.";
        }
    }
}
