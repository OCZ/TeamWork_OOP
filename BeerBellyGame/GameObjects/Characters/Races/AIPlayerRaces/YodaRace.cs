namespace BeerBellyGame.GameObjects.Characters.Races.AIPlayerRaces
{
    using Attributes;

    [FriendRace]
    public class YodaRace : AbstractRace
    {
        public YodaRace()
            : base(AppSettings.YodaAggressionRange, AppSettings.YodaAggression, AppSettings.YodaAvatar, AppSettings.YodaDescription)
        {       
        }
    }
}
