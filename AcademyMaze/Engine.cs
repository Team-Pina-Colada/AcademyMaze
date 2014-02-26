namespace AcademyMaze
{
    using System;
    using System.Collections.Generic;

    public class Engine
    {
        private const int PlayerStartCoordinateX = 5;
        private const int PlayerStartCoordinateY = 0;

        private Map someMap;
        private Random rnd;

        public Engine(PlayerType playerType)
        {
            this.PlayerType = playerType;
            this.rnd = new Random();
        }

        private Player HumanPlayer { get; set; }

        private PlayerType PlayerType { get; set; }

        private List<WorldObject> AllObjects { get; set; }

        public void Start()
        {
            this.LoadLevel();
            this.HumanPlayer = new Player(new Coordinates(PlayerStartCoordinateX, PlayerStartCoordinateY), this.PlayerType);
        }

        public bool CheckIfEmpty(Coordinates enemyCoordinate)
        {
            if (this.HumanPlayer.CurrentPosition.CoordinateX == enemyCoordinate.CoordinateX && this.HumanPlayer.CurrentPosition.CoordinateY == enemyCoordinate.CoordinateY)
            {
                return false;
            }

            foreach (var item in this.AllObjects)
            {
                if (item.StartingPosition.CoordinateX == enemyCoordinate.CoordinateX && item.StartingPosition.CoordinateY == enemyCoordinate.CoordinateY)
                {
                    return false;
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

        // TODO: Initialize the game objects
        //private void InitializeObjectsByType(int count, Type type)
        //{
        //    Coordinates newObjectCoordinate = new Coordinates();
        //    newObjectCoordinate.CoordinateX = this.rnd.Next(0, this.someMap.Height);
        //    newObjectCoordinate.CoordinateY = this.rnd.Next(0, this.someMap.Width);

        //    if (this.CheckIfEmpty(newObjectCoordinate))
        //    {
        //        this.AllObjects.Add((type)Activator.CreateInstance(type));
        //    }
        //}
    }
}
