namespace BeerBellyGame.GameObjects.Characters.Races.PlayerRaces
{
    public class PickachuRace: AbstractRace
    {
        private const string PickachuAvatar = "/Content/Characters/pikachu_v1.png";
        private const string PickachuDescription = "Pikachu, the yellow hero";
        private const int PickachuAggressionRange = 2;
        private const double PickachuAggression = 100.2;

        public PickachuRace()
            : base( PickachuAggressionRange,
                    PickachuAggression, 
                    PickachuAvatar,
                    PickachuDescription)
        {
        }
    }
}
