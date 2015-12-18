namespace BeerBellyGame.GameObjects.Characters.Races.AIPlayerRaces
{
    using Attributes;

    [EnemyRace]
    public class LeprechaunRace: AbstractRace
    {
        public LeprechaunRace() : base( AppSettings.RaceAggressionRangeLeprechaun, 
                                        AppSettings.RaceAggressionLeprechaun, 
                                        AppSettings.RaceAvatarLeprechaun,
                                        AppSettings.RaceDescriptionLeprechaun)
        {
        }
    }
}
