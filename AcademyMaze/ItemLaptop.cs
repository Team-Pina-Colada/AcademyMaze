﻿namespace AcademyMaze
{
    using AcademyMaze.Interfaces;

    public class ItemLaptop : Item, IGiveBonus
    {
        public ItemLaptop(Coordinates initialCoordinates)
            : base(initialCoordinates)
        {
        }

        public void IncreaseHeroStats(Player player)
        {
            player.Intelligence++;
        }
    }
}
