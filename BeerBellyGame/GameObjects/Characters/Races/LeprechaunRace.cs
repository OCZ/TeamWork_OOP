namespace BeerBellyGame.GameObjects.Characters.Races
{
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
