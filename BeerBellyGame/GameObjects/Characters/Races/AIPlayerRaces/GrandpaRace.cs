namespace BeerBellyGame.GameObjects.Characters.Races.AIPlayerRaces
{
    using Attributes;

    [EnemyRace]
    public class GrandpaRace : AbstractRace
    {
        public GrandpaRace()
            : base(AppSettings.SuperGrandpaAggressionRange, AppSettings.SuperGrandpaAggression, AppSettings.SuperGrandpaAvatar, AppSettings.SuperGrandpaDescription)
        {
        }
    }
}
