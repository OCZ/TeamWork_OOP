namespace BeerBellyGame.GameObjects.Characters.Races.PlayerRaces
{
    using Attributes;

    [PlayerRace]
    public class ChuckNorrisRace : AbstractRace
    {
        private const string ChuckAvatar = "/Content/Characters/chucknorrist.gif";
        private const string ChuckDescription = "Chuck Norris,you are totally adicted to beer, that's why withouth beer you are very very aggressive.";
        private const int ChuckAggressionRange = 5;
        private const double ChuckAggression = 500.2;

        public ChuckNorrisRace()
            : base(ChuckAggressionRange, ChuckAggression, ChuckAvatar, ChuckDescription)
        {
        }
    }
}
