namespace BeerBellyGame.GameObjects.Characters.Factories
{
    using Interfaces;

    // TODO: implement ICOllection of races for Friend and Enemy and add randomly submission to constructor 

    public class EnemyFactory: CharacterFactory, IRandomRace
    {
        public override Character Create(IRace race)
        {
            var enemy = new Enemy(race);
            return enemy;
        }

     
        public IRace GetRace()
        {
            // TODO: implement randomly select rom EnemyRaces and submit to constructor 
            return null;
        }
    }
}
