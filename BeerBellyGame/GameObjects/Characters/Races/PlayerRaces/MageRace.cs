namespace BeerBellyGame.GameObjects.Characters.Races.PlayerRaces
{
    using Attributes;

    [PlayerRace]
    public class MageRace : AbstractRace
    {
    
        public MageRace()
            : base(AppSettings.MageAggressionRange, 
                   AppSettings.MageAggression, 
                   AppSettings.MageAvatar, 
                   AppSettings.MageDescription)
        {
        }
    }
}
