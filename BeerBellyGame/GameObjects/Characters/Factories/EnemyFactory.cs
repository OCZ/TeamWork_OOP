namespace BeerBellyGame.GameObjects.Characters.Factories
{
    using AI;
    using Interfaces;

    public class EnemyFactory: CharacterFactory
    {
        private static int counter = 0;
        
        public override Character Create(IRace race)
        {
            var enemy = new Enemy(race, GetAI());
            return enemy;
        }

       
        private AIProvider GetAI()
        {
            counter++;
            if (counter < AppSettings.TargetAICount)
            {
                return new TargetCharacterAIProvider();
            }
            
            return new RandomAIProvider();
        }
    }
}
