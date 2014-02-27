namespace AcademyMaze
{
    using AcademyMaze.Interfaces;

    public class Ally : WorldObject, IGiveBonus
    {
        private const int IvoInteligenceBonus = 1;
        private const int IvoMotivationBonus = 4;
        private const int JoroInteligenceBonus = 3;
        private const int JoroMotivationBonus = 2;
        private const int NikiInteligenceBonus = 4;
        private const int NikiMotivationBonus = 1;
        private const int DonchoInteligenceBonus = 2;
        private const int DonchoMotivationBonus = 3;

        private AllyType allyType;

        public Ally(Coordinates initialCoordinates, AllyType trainer)
            : base(initialCoordinates)
        {
            this.allyType = trainer;
        }

        public virtual void IncreaseHeroStats(Player player)
        {
            switch (allyType)
            {
                case AllyType.Ivo:
                    player.Intelligence += IvoInteligenceBonus;
                    player.Motivation += IvoMotivationBonus;
                    break;
                case AllyType.Joro:
                    player.Intelligence += JoroInteligenceBonus;
                    player.Motivation += JoroMotivationBonus;
                    break;
                case AllyType.Niki:
                    player.Intelligence += NikiInteligenceBonus;
                    player.Motivation += NikiMotivationBonus;
                    break;
                case AllyType.Doncho:
                    player.Intelligence += DonchoInteligenceBonus;
                    player.Motivation += DonchoMotivationBonus;
                    break;
            }
        }

        public override string InteractNotification()
        {
            switch (this.allyType)
            {
                case AllyType.Ivo:
                    return "You've just watched one of Ivo's lections.\nCongratulations, you are even more motivated.";
                case AllyType.Joro:
                    return "You've just watched one of Joro's lections.\nCongratulations, your stats increased.";
                case AllyType.Niki:
                    return "You've just watched one of Niki's lections.\nCongratulations, your abstraction is on a greater level.";
                case AllyType.Doncho:
                    return "You've just watched one of Doncho's lections.\nCongratulations, your stats increased.";
                default:
                    return string.Empty;
            }
        }
    }
}
