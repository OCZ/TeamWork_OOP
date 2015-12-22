namespace BeerBellyGame.GameObjects.Characters.Races.PlayerRaces
{
    using Attributes;

    [PlayerRace]
    public class ChuckNorrisRace : AbstractRace
    {
       public ChuckNorrisRace()
            : base(AppSettings.ChuckAggressionRange, AppSettings.ChuckAggression, AppSettings.ChuckAvatar, AppSettings.ChuckDescription)
        {
        }
    }
}
