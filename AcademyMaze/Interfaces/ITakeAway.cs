namespace AcademyMaze.Interfaces
{
    // This interface will be implemented by enemies that can take away some of your skills
    public interface ITakeAway
    {
        void ReduceHeroStats(Player player);
    }
}
