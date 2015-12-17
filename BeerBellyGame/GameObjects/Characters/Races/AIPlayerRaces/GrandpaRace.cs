namespace BeerBellyGame.GameObjects.Characters.Races.AIPlayerRaces
{
    using Atributes;

    [Enemy]
    public class GrandpaRace : AbstractRace
    {
        private const string SuperGrandpaAvatar = "/Content/Characters/grandpa.png";
        private const string SuperGrandpaDescription = "GrandPa";
        private const int    SuperGrandpaAggressionRange = 3;
        private const double SuperGrandpaAggression = 300.2;

        public GrandpaRace()
            : base(SuperGrandpaAggressionRange, SuperGrandpaAggression, SuperGrandpaAvatar, SuperGrandpaDescription)
        {
        }
    }
}
