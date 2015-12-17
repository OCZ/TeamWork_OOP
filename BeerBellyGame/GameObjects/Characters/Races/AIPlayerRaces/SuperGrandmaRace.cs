namespace BeerBellyGame.GameObjects.Characters.Races.AIPlayerRaces
{
    using Atributes;

    [Friend]
    public class SuperGrandmaRace : AbstractRace
    {
        private const string SuperGrandmaAvatar = "/Content/Characters/grandma.png";
        private const string SuperGrandmaDescription = "GrandMa";
        private const int    SuperGrandmaAggressionRange = 3;
        private const double SuperGrandmaAggression = 300.2;

        public SuperGrandmaRace()
            : base(SuperGrandmaAggressionRange, SuperGrandmaAggression, SuperGrandmaAvatar, SuperGrandmaDescription)
        {
        }
    }
}
