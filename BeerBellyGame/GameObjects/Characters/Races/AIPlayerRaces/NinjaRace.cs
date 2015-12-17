namespace BeerBellyGame.GameObjects.Characters.Races.AIPlayerRaces
{
    using Atributes;

    [Enemy]
    public class NinjaRace: AbstractRace
    {
        private const string NinjaAvatar = "/Content/Characters/ninja.png.png";
        private const string NinjaDescription = "Ninja";
        private const int    NinjaAggressionRange = 3;
        private const double NinjaAggression = 300.2;

        public NinjaRace()
            : base(
                NinjaAggressionRange,
                NinjaAggression,
                NinjaAvatar,
                NinjaDescription)
        {       
        }
    }
}
