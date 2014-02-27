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

        public override string InteractNotification()
        {
            return "You drunk 3,4,5 beers. Now you don't want to study enymore. Your motivations decreased.";
        }
    }
}
