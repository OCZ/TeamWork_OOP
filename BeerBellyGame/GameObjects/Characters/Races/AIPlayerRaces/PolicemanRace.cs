namespace BeerBellyGame.GameObjects.Characters.Races.AIPlayerRaces
{
    using Attributes;

    [FriendRace]
    public class PolicemanRace: AbstractRace
    {
        private const string RaceAvatarPoliceman = "/Content/Characters/policeman.png";
        private const string RaceDescriptionPoliceman = "policeman the blue hero";
        private const int RaceAggressionRangePoliceman = 2;
        private const double RaceAggressionPoliceman = 20.5;
        
        public PolicemanRace()
            : base( RaceAggressionRangePoliceman, 
                    RaceAggressionPoliceman, 
                    RaceAvatarPoliceman, 
                    RaceDescriptionPoliceman )
        {
        }
    }
}
