namespace BeerBellyGame.GameObjects.Characters.Races
{
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
