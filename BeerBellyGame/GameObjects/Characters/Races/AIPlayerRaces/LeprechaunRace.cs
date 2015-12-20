namespace BeerBellyGame.GameObjects.Characters.Races.AIPlayerRaces
{
    using Attributes;

    [EnemyRace]
    public class LeprechaunRace: AbstractRace
    {
        
        private const string LeprechaunAvatar = "/Content/Characters/leprechaun_v2.png";
        private const string LeprechaunDescription = "Leprechaun the green hero";
        private const int    LeprechaunAggressionRange = 1;
        private const double LeprechaunAggression = 300.2;

        public LeprechaunRace(): base(  LeprechaunAggressionRange,
                                        LeprechaunAggression,
                                        LeprechaunAvatar,
                                        LeprechaunDescription)
        {                               
        }
    }
}
