namespace BeerBellyGame.GameObjects.Characters.Races.AIPlayerRaces
{
    using Attributes;

    [FriendRace]
    public class SuperGrandmaRace : AbstractRace
    {
        public SuperGrandmaRace()
            : base(AppSettings.SuperGrandmaAggressionRange, AppSettings.SuperGrandmaAggression, AppSettings.SuperGrandmaAvatar, AppSettings.SuperGrandmaDescription)
        {
        }
    }
}
