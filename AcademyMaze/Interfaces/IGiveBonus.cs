namespace AcademyMaze.Interfaces
{
    // This interface will be implemented by classes which instances can give some bonus to our player skills(like items or allies)
    public interface IGiveBonus
    {
        void IncreaseHeroStats(Player player);
    }
}
