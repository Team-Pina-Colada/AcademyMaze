namespace AcademyMaze
{
    using System;

    public class WrongAnswerException : ApplicationException
    {
        public WrongAnswerException()
        {
        }

        public override string Message
        {
            get
            {
                return "Sorry, wrong answer.";
            }
        }
    }
}
