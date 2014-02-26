namespace AcademyMaze
{
    using AcademyMaze.Interfaces;

    public class ItemBeer : Item, ITakeAway
    {
        public ItemBeer(Coordinates initialCoordinates)
            : base(initialCoordinates)
        {
        }

        public void ReduceHeroStats(Player player)
        {
            player.Motivation--;
        }
    }
}
