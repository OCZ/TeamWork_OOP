namespace BeerBellyGame.GameObjects.Characters.Races.PlayerRaces
{
    using Attributes;

    [PlayerRace]
    public class MageRace : AbstractRace
    {
        private const string MageAvatar = "/Content/Characters/mage.png";
        private const string MageDescription = "MAGE, beer is regular part of your life so life is like a magic for you. You are medium aggressive";
        private const int MageAggressionRange = 150;
        private const double MageAggression = 300.2;

        public MageRace()
            : base(MageAggressionRange, MageAggression, MageAvatar, MageDescription)
        {
        }
    }
}
