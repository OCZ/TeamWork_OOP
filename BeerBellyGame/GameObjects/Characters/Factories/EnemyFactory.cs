namespace BeerBellyGame.GameObjects.Characters.Factories
{
    using BeerBellyGame.GameObjects.AI;
    using Interfaces;
    using Races;
    using System;

    // TODO: implement ICOllection of races for Friend and Enemy and add randomly submission to constructor 

    public class EnemyFactory: CharacterFactory
    {
        private static int counter = 0;
        public override Character Create()
        {
            IRace race = this.GetRace();
            var enemy = new Enemy(race, GetAI());
            return enemy;
        }

        public override IRace GetRace()
        {
            //TODO =>  radomly generate Enemy Race
            IRace race = new PolicemanRace();

            return race;
        }

        private AIProvider GetAI()
        {
            counter++;
            if (counter < 2)
            {
                return new TargetCharacterAIProvider();
            }
            
            return new RandomAIProvider();
        }
    }
}
