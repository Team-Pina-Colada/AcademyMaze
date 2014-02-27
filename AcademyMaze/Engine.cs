namespace AcademyMaze
{
    using System;
    using System.Collections.Generic;
    using AcademyMaze.Interfaces;

    public class Engine
    {
        private const int PlayerStartCoordinateX = 5;
        private const int PlayerStartCoordinateY = 0;

        private Map someMap;
        private Random rnd;
        private IUserInterface inputInterface;

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
            this.LoadLevel();
            this.HumanPlayer = new Player(new Coordinates(PlayerStartCoordinateX, PlayerStartCoordinateY), this.PlayerType);
            HumanPlayer.DrawPlayer();
            DrawStats();
            this.InitializeObjects();

            this.inputInterface.OnLeftPressed += MovePlayer;
            this.inputInterface.OnRightPressed += MovePlayer;
            this.inputInterface.OnUpPressed += MovePlayer;
            this.inputInterface.OnDownPressed += MovePlayer;

            while (true)
            {
                this.inputInterface.ProcessInput();
                Console.Clear();
                this.someMap.DrawMap();
                this.HumanPlayer.DrawPlayer();
                DrawStats();
            }
        }

        private void MovePlayer(object Sender, DirectionSetEvent args)
        {
            switch (args.SetDirection)
            {
                case Direction.Left:
                    if (HumanPlayer.CurrentPosition.CoordinateY > 0)
                    {
                        HumanPlayer.MoveLeft();
                        CheckField();
                    }
                    break;
                case Direction.Right:
                    if (HumanPlayer.CurrentPosition.CoordinateY < this.someMap.Width - 1)
                    {
                        HumanPlayer.MoveRight();
                        CheckField();
                    }
                    break;
                case Direction.Up:
                    if (HumanPlayer.CurrentPosition.CoordinateX > 0)
                    {
                        HumanPlayer.MoveUp();
                        CheckField();
                    }
                    break;
                case Direction.Down:
                    if (HumanPlayer.CurrentPosition.CoordinateX < this.someMap.Height - 1)
                    {
                        HumanPlayer.MoveDown();
                        CheckField();
                    }
                    break;
            }
        }

        private void CheckField()
        {
            foreach (var item in this.AllObjects)
            {
                if (HumanPlayer.CurrentPosition == item.StartingPosition)
                {
                    InteractWithField(item);
                }
            }
        }

        private void InteractWithField(WorldObject item)
        {
            Console.SetCursorPosition(0, this.someMap.Height + 3);
            if (item is IGiveBonus)
            {
                (item as IGiveBonus).IncreaseHeroStats(this.HumanPlayer);
                Console.WriteLine(item.InteractNotification());
            }
            Console.ReadKey();
        }

        private void InitializeObjects()
        {
            //this.AllObjects.Add(new ExamCSharpOne(CreateCoordinates()));
            //this.AllObjects.Add(new ExamCSharpTwo(CreateCoordinates()));
            //this.AllObjects.Add(new ExamOop(CreateCoordinates()));
            //this.AllObjects.Add(new HomeworkTask(CreateCoordinates()));
            //this.AllObjects.Add(new HomeworkTask(CreateCoordinates()));
            //this.AllObjects.Add(new HomeworkTask(CreateCoordinates()));
            //this.AllObjects.Add(new HomeworkTask(CreateCoordinates()));
            //this.AllObjects.Add(new HomeworkTask(CreateCoordinates()));
            //this.AllObjects.Add(new HomeworkTask(CreateCoordinates()));
            this.AllObjects.Add(new MutteringGirlfriend(CreateCoordinates()));
            this.AllObjects.Add(new DrinkingParty(CreateCoordinates()));
            this.AllObjects.Add(new DrinkingParty(CreateCoordinates()));
            this.AllObjects.Add(new DrinkingParty(CreateCoordinates()));
            this.AllObjects.Add(new ItemBeer(CreateCoordinates()));
            this.AllObjects.Add(new ItemBeer(CreateCoordinates()));
            this.AllObjects.Add(new ItemLaptop(CreateCoordinates()));
            this.AllObjects.Add(new Ally(CreateCoordinates(), AllyType.Ivo));
            this.AllObjects.Add(new Ally(CreateCoordinates(), AllyType.Joro));
            this.AllObjects.Add(new Ally(CreateCoordinates(), AllyType.Niki));
            this.AllObjects.Add(new Ally(CreateCoordinates(), AllyType.Doncho));
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

        private void LoadLevel()
        {
            Console.Clear();
            this.someMap = new Map(MapType.Easy);
            this.someMap.DrawMap();
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
        }


    }
}
