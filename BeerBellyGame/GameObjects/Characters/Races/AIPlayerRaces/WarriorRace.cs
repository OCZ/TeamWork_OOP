namespace BeerBellyGame.GameObjects.Characters.Races.AIPlayerRaces
{
    using Attributes;

    [EnemyRace]
    public class WarriorRace: AbstractRace
    {
        public WarriorRace()
            : base(AppSettings.WarriorAggressionRange, AppSettings.WarriorAggression, AppSettings.WarriorAvatar, AppSettings.WarriorDescription)
        {
        }
    }
}
