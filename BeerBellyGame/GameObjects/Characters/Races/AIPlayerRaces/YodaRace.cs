namespace BeerBellyGame.GameObjects.Characters.Races.AIPlayerRaces
{
    using Attributes;

    [FriendRace]
    public class YodaRace : AbstractRace
    {
        private const string YodaAvatar = "/Content/Characters/yoda.png";
        private const string YodaDescription = "Yoda";
        private const int    YodaAggressionRange = 3;
        private const double YodaAggression = 300.2;

        public YodaRace()
            : base(
                YodaAggressionRange,
                YodaAggression,
                YodaAvatar,
                YodaDescription)
        {       
        }
    }
}
