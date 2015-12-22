namespace BeerBellyGame.GameObjects.Characters.Races.AIPlayerRaces
{
    using Attributes;

    [EnemyRace]
    public class LeprechaunRace: AbstractRace
    {
        public LeprechaunRace(): base(AppSettings.LeprechaunAggressionRange, AppSettings.LeprechaunAggression, AppSettings.LeprechaunAvatar, AppSettings.LeprechaunDescription)
        {                               
        }
    }
}
