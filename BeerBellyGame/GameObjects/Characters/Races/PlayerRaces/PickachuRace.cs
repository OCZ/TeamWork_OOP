namespace BeerBellyGame.GameObjects.Characters.Races.PlayerRaces
{
    using Attributes;

    [PlayerRace]
    public class PickachuRace: AbstractRace
    {
        private const string PickachuAvatar = "/Content/Characters/pikachu_v1.png";
        private const string PickachuDescription = "Pikachu, the yellow hero";
        private const int PickachuAggressionRange = 100;
        private const double PickachuAggression = 50;

        public PickachuRace()
            : base( PickachuAggressionRange,
                    PickachuAggression, 
                    PickachuAvatar,
                    PickachuDescription)
        {
        }
    }
}
