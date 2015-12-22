namespace BeerBellyGame.GameObjects.Characters.Races.AIPlayerRaces
{
    using Attributes;

    [FriendRace]
    public class PolicemanRace: AbstractRace
    {
        public PolicemanRace()
            : base(AppSettings.RaceAggressionRangePoliceman, AppSettings.RaceAggressionPoliceman, AppSettings.RaceAvatarPoliceman, AppSettings.RaceDescriptionPoliceman )
        {
        }
    }
}
