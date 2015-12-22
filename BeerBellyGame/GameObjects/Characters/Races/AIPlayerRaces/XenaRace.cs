namespace BeerBellyGame.GameObjects.Characters.Races.AIPlayerRaces
{
    using Attributes;

    [FriendRace]
    public class XenaRace : AbstractRace
    {
        public XenaRace()
            : base(AppSettings.XenaAggressionRange, AppSettings.XenaAggression, AppSettings.XenaAvatar, AppSettings.XenaDescription)
        {
        }
    }
}
