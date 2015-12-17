namespace BeerBellyGame.GameObjects.Characters.Races.AIPlayerRaces
{
    using Atributes;

    [Friend]
    public class XenaRace : AbstractRace
    {
        private const string XenaAvatar = "/Content/Characters/xena.png";
        private const string XenaDescription = "Xena Warrior Princess";
        private const int    XenaAggressionRange = 3;
        private const double XenaAggression = 300.2;
                             
        public XenaRace()
            : base(
            XenaAggressionRange, 
            XenaAggression, 
            XenaAvatar, 
            XenaDescription)
        {
        }
    }
}
