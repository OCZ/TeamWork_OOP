namespace BeerBellyGame.GameObjects.Characters.Races
{
    public class PickachuRace: AbstractRace
    {
        public PickachuRace()
            : base( AppSettings.RaceAggressionRangePickachu, 
                    AppSettings.RaceAggressionPickachu, 
                    AppSettings.RaceAvatarPickachu, 
                    AppSettings.RaceDescriptionPickachu)
        {
        }
    }
}
