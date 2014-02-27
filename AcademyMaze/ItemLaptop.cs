namespace AcademyMaze
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

        public override string InteractNotification()
        {
            return "You found a new Laptop.\nCongratulations, your Inteligence increased";
        }
    }
}
