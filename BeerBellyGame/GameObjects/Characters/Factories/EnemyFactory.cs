namespace BeerBellyGame.GameObjects.Characters.Factories
{
    using BeerBellyGame.GameObjects.AI;
    using Interfaces;
    using Races;
    using System;
    using System.Linq;
    using System.Reflection;
    using Atributes;

    // TODO: implement ICOllection of races for Friend and Enemy and add randomly submission to constructor 
   
    public class EnemyFactory: CharacterFactory
    {
        private static int counter = 0;
        private static readonly Random Rand = new Random();

        public override Character Create()
        {
            var race = this.GetRace();
            var enemy = new Enemy(race, GetAI());
            return enemy;
        }

        public override IRace GetRace()
        {
            var enemyRaces = Assembly.GetExecutingAssembly().GetTypes()
                .Where(t => t.IsClass)
                .Where(t => t.CustomAttributes.Any(a => a.AttributeType == typeof(EnemyAttribute)))
                .ToArray();

            int index = Rand.Next(0, enemyRaces.Length);

            var race = Activator.CreateInstance(enemyRaces[index]) as IRace;

            return race;
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
