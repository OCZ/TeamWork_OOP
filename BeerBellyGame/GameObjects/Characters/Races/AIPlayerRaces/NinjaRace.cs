namespace BeerBellyGame.GameObjects.Characters.Races.AIPlayerRaces
{
    using Attributes;

    [EnemyRace]
    public class NinjaRace: AbstractRace
    {
        public NinjaRace()
            : base(AppSettings.NinjaAggressionRange, AppSettings.NinjaAggression, AppSettings.NinjaAvatar, AppSettings.NinjaDescription)
        {       
        }
    }
}
