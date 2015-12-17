namespace BeerBellyGame.GameObjects.Characters.Races.AIPlayerRaces
{
    using Atributes;

    [Friend]
    public class PolicemanRace: AbstractRace
    {
        
        public PolicemanRace()
            : base( AppSettings.RaceAggressionRangePoliceman, 
                    AppSettings.RaceAggressionPoliceman, 
                    AppSettings.RaceAvatarPoliceman, 
                    AppSettings.RaceDescriptionPoliceman )
        {
        }
    }
}
