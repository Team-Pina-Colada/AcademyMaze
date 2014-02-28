namespace AcademyMaze
{
    using System;
    using System.Collections.Generic;
    using AcademyMaze.Interfaces;

    public class Engine
    {
        private const int PlayerStartCoordinateX = 5;
        private const int PlayerStartCoordinateY = 0;

        private readonly Random rnd;
        private readonly IUserInterface inputInterface;
        private Map someMap;

        public Engine(PlayerType playerType, IUserInterface inputInterface)
        {
            this.PlayerType = playerType;
            this.rnd = new Random();
            this.inputInterface = inputInterface;
            this.AllObjects = new List<WorldObject>();
        }

        private Player HumanPlayer { get; set; }

        private PlayerType PlayerType { get; set; }

        private List<WorldObject> AllObjects { get; set; }

        public void Start()
        {
            this.someMap = new Map(MapType.Easy);
            this.HumanPlayer = new Player(new Coordinates(PlayerStartCoordinateX, PlayerStartCoordinateY), this.PlayerType);
            this.DrawAll();
            this.InitializeObjects();

            this.inputInterface.OnLeftPressed += this.MovePlayer;
            this.inputInterface.OnRightPressed += this.MovePlayer;
            this.inputInterface.OnUpPressed += this.MovePlayer;
            this.inputInterface.OnDownPressed += this.MovePlayer;

            while (true)
            {
                this.inputInterface.ProcessInput();
                this.DrawAll();
            }
        }

        public bool CheckIfEmpty(Coordinates enemyCoordinate)
        {
            if (this.HumanPlayer.CurrentPosition.CoordinateX == enemyCoordinate.CoordinateX && this.HumanPlayer.CurrentPosition.CoordinateY == enemyCoordinate.CoordinateY)
            {
                return false;
            }

            if (this.AllObjects != null)
            {
                foreach (var item in this.AllObjects)
                {
                    if (item.StartingPosition.CoordinateX == enemyCoordinate.CoordinateX && item.StartingPosition.CoordinateY == enemyCoordinate.CoordinateY)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        private void DrawAll()
        {
            Console.Clear();
            this.someMap.DrawMap();
            this.HumanPlayer.DrawPlayer();
            this.DrawStats();
        }

        private void MovePlayer(object sender, DirectionSetEvent args)
        {
            switch (args.SetDirection)
            {
                case Direction.Left:
                    if (this.HumanPlayer.CurrentPosition.CoordinateY > 0)
                    {
                        this.HumanPlayer.MoveLeft();
                        this.someMap.WorldMap[this.HumanPlayer.CurrentPosition.CoordinateX, this.HumanPlayer.CurrentPosition.CoordinateY] = true;
                        this.CheckField();
                    }

                    break;
                case Direction.Right:
                    if (this.HumanPlayer.CurrentPosition.CoordinateY < this.someMap.Width - 1)
                    {
                        this.HumanPlayer.MoveRight();
                        this.someMap.WorldMap[this.HumanPlayer.CurrentPosition.CoordinateX, this.HumanPlayer.CurrentPosition.CoordinateY] = true;
                        this.CheckField();
                    }

                    break;
                case Direction.Up:
                    if (this.HumanPlayer.CurrentPosition.CoordinateX > 0)
                    {
                        this.HumanPlayer.MoveUp();
                        this.someMap.WorldMap[this.HumanPlayer.CurrentPosition.CoordinateX, this.HumanPlayer.CurrentPosition.CoordinateY] = true;
                        this.CheckField();
                    }

                    break;
                case Direction.Down:
                    if (this.HumanPlayer.CurrentPosition.CoordinateX < this.someMap.Height - 1)
                    {
                        this.HumanPlayer.MoveDown();
                        this.someMap.WorldMap[this.HumanPlayer.CurrentPosition.CoordinateX, this.HumanPlayer.CurrentPosition.CoordinateY] = true;
                        this.CheckField();
                    }

                    break;
            }
        }

        private void CheckField()
        {
            foreach (var item in this.AllObjects)
            {
                if (this.HumanPlayer.CurrentPosition == item.StartingPosition)
                {
                    this.InteractWithField(item);
                    break;
                }
            }
        }

        private void InteractWithField(WorldObject item)
        {
            Console.SetCursorPosition(0, this.someMap.Height + 3);

            if (item is IOptionable)
            {
                if (!this.WillYouStepOnThisField(item as IOptionable))
                {
                    this.someMap.WorldMap[this.HumanPlayer.CurrentPosition.CoordinateX, this.HumanPlayer.CurrentPosition.CoordinateY] = false;
                    return;
                }
            }

            if (item is IGiveBonus)
            {
                if (item is Exam)
                {
                    this.DrawAll();
                    var currentExam = item as Exam;
                    Console.WriteLine("You have encauntered an {0} Exam.", currentExam.GetType().Name.Replace("Exam", string.Empty));

                    while (currentExam.HitPoints > 0)
                    {
                        if (currentExam.CurrentlyAskedQuestion >= currentExam.TotalQUestions || this.HumanPlayer.Motivation <= 0)
                        {
                            this.GameOver();
                        }

                        try
                        {
                            this.HandleQuestion(currentExam.AskQuestion());
                            currentExam.HitPoints -= this.HumanPlayer.Intelligence > 10 ? 2 : 1;
                        }
                        catch (WrongAnswerException e)
                        {
                            this.HumanPlayer.Motivation -= currentExam.AttackPoints;
                            Console.WriteLine(e.Message);
                        }

                        Console.ReadKey();

                        this.DrawAll();
                    }

                    (item as IGiveBonus).IncreaseHeroStats(this.HumanPlayer);
                    Console.WriteLine(item.InteractNotification());
                }
                else if (item is HomeworkTask)
                {
                    var currentTask = item as HomeworkTask;
                    Console.WriteLine("This is the last task of your homework.\nYou don't have much time, answer ASAP");

                    try
                    {
                        this.HandleQuestion(currentTask.AskQuestion());
                        (item as IGiveBonus).IncreaseHeroStats(this.HumanPlayer);
                        Console.WriteLine(item.InteractNotification());
                    }
                    catch (WrongAnswerException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
                else
                {
                    (item as IGiveBonus).IncreaseHeroStats(this.HumanPlayer);
                    Console.WriteLine(item.InteractNotification());
                }

                this.AllObjects.Remove(item);
            }
            else if (item is ITakeAway)
            {
                Console.WriteLine("Bad luck, you found your {0}.", item.GetType().Name.Replace("Item", string.Empty));
                (item as ITakeAway).ReduceHeroStats(this.HumanPlayer);
                Console.WriteLine(item.InteractNotification());
                this.AllObjects.Remove(item);
            }

            Console.ReadKey();
        }

        private bool WillYouStepOnThisField(IOptionable item)
        {
            bool correctInput = false;
            bool result = false;

            while (!correctInput)
            {
                this.DrawAll();
                Console.Write("You have encountered {0}.\nAre you ready to face it? (y/n)", item.GetType().Name);
                string userInput = Console.ReadLine();

                if (userInput == "n")
                {
                    result = false;
                    break;
                }
                else if (userInput == "y")
                {
                    result = true;
                    break;
                }
                else
                {
                    Console.WriteLine("Wrong input, try again.");
                    Console.ReadKey();
                }
            }

            return result;
        }

        private void HandleQuestion(Question currentQuestion)
        {
            Console.WriteLine(currentQuestion);
            Console.Write("Your answer (1-{0}):", currentQuestion.Answers.Count);
            int answer = int.Parse(Console.ReadLine());
            if (answer != currentQuestion.CorrectAnswer + 1)
            {
                throw new WrongAnswerException();
            }

            Console.WriteLine("Answer is correct");
        }

        private void InitializeObjects()
        {
            this.AllObjects.Add(new ExamCSharpOne(this.CreateCoordinates()));
            this.AllObjects.Add(new ExamCSharpTwo(this.CreateCoordinates()));
            this.AllObjects.Add(new ExamOop(this.CreateCoordinates()));
            this.AllObjects.Add(new HomeworkTask(this.CreateCoordinates()));
            this.AllObjects.Add(new HomeworkTask(this.CreateCoordinates()));
            this.AllObjects.Add(new HomeworkTask(this.CreateCoordinates()));
            this.AllObjects.Add(new HomeworkTask(this.CreateCoordinates()));
            this.AllObjects.Add(new HomeworkTask(this.CreateCoordinates()));
            this.AllObjects.Add(new HomeworkTask(this.CreateCoordinates()));
            this.AllObjects.Add(new MutteringGirlfriend(this.CreateCoordinates()));
            this.AllObjects.Add(new DrinkingParty(this.CreateCoordinates()));
            this.AllObjects.Add(new DrinkingParty(this.CreateCoordinates()));
            this.AllObjects.Add(new DrinkingParty(this.CreateCoordinates()));
            this.AllObjects.Add(new ItemBeer(this.CreateCoordinates()));
            this.AllObjects.Add(new ItemBeer(this.CreateCoordinates()));
            this.AllObjects.Add(new ItemLaptop(this.CreateCoordinates()));
            this.AllObjects.Add(new Ally(this.CreateCoordinates(), AllyType.Ivo));
            this.AllObjects.Add(new Ally(this.CreateCoordinates(), AllyType.Joro));
            this.AllObjects.Add(new Ally(this.CreateCoordinates(), AllyType.Niki));
            this.AllObjects.Add(new Ally(this.CreateCoordinates(), AllyType.Doncho));
        }

        private Coordinates CreateCoordinates()
        {
            Coordinates newObjectCoordinate = new Coordinates();
            do
            {
                newObjectCoordinate.CoordinateX = this.rnd.Next(0, this.someMap.Height);
                newObjectCoordinate.CoordinateY = this.rnd.Next(0, this.someMap.Width);
            }
            while (!this.CheckIfEmpty(newObjectCoordinate));

            return newObjectCoordinate;
        }

        private void DrawStats()
        {
            Console.SetCursorPosition(this.someMap.Width + 5, 3);
            Console.WriteLine("Inteligence: {0}", this.HumanPlayer.Intelligence);
            Console.SetCursorPosition(this.someMap.Width + 5, 4);
            Console.WriteLine("Motivation:  {0}", this.HumanPlayer.Motivation);
            Console.SetCursorPosition(0, this.someMap.Height + 3);
        }

        private void GameOver()
        {
            Console.Clear();
            Console.WriteLine("You failed in your training as .NET NINJA.\nBut don't dispare you can try again.");
            Console.ReadKey(true);
            Environment.Exit(0);
        }
    }
}
