namespace BeerBellyGame.GameObjects.Characters.Races.PlayerRaces
{
    using Attributes;

    [PlayerRace]
    public class PickachuRace: AbstractRace
    {
        public PickachuRace()
            : base( AppSettings.PickachuAggressionRange,
                    AppSettings.PickachuAggression, 
                    AppSettings.PickachuAvatar,
                    AppSettings.PickachuDescription)
        {
        }
    }
}
