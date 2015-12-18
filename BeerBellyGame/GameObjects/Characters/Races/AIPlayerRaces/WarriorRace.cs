namespace BeerBellyGame.GameObjects.Characters.Races.AIPlayerRaces
{
    using Attributes;

    [EnemyRace]
    public class WarriorRace: AbstractRace
    {
        private const string WarriorAvatar = "/Content/Characters/warrior.png";
        private const string WarriorDescription = "Warrior";
        private const int    WarriorAggressionRange = 3;
        private const double WarriorAggression = 300.2;

        public WarriorRace()
            : base(
            WarriorAggressionRange, 
            WarriorAggression, 
            WarriorAvatar, 
            WarriorDescription)
        {
        }
    }
}
