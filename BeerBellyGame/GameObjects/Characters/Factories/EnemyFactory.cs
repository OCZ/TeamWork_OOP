namespace BeerBellyGame.GameObjects.Characters.Factories
{
    using AI;
    using Interfaces;

    public class EnemyFactory: CharacterFactory
    {
        private static int _counter = 0;
        
        public override Character Create(IRace race)
        {
            var enemy = new Enemy(race, GetAI());
            return enemy;
        }

       
        private AIProvider GetAI()
        {
            _counter++;
            if (_counter < AppSettings.TargetAICount)
            {
                return new TargetCharacterAIProvider();
            }
            
            return new RandomAIProvider();
        }
    }
}
