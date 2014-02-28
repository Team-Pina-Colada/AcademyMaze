namespace AcademyMaze
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Question
    {
        public Question(string askedQuestion, ICollection<string> answers, int correctAnswer)
        {
            if (correctAnswer >= answers.Count || string.IsNullOrWhiteSpace(askedQuestion) || answers == null)
            {
                throw new ArgumentException("Incorrect value");
            }

            this.AskedQuestion = askedQuestion;
            this.Answers = answers;
            this.CorrectAnswer = correctAnswer;
        }

        public string AskedQuestion { get; private set; }

        public ICollection<string> Answers { get; private set; }

        public int CorrectAnswer { get; private set; }

        public bool ValidateCorrectAnswer(int givenAnswer)
        {
            if (this.CorrectAnswer == givenAnswer)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override string ToString()
        {
            StringBuilder formatedQuestion = new StringBuilder();
            formatedQuestion.AppendLine(this.AskedQuestion);

            int count = 1;
            foreach (var answer in this.Answers)
            {
                formatedQuestion.AppendLine(count + ". " + answer);
                count++;
            }

            return formatedQuestion.ToString();
        }
    }
}
