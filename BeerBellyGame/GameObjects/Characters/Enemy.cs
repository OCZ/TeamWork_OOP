namespace BeerBellyGame.GameObjects.Characters
{
    using BeerBellyGame.GameObjects.AI;
    using BeerBellyGame.GameObjects.Items;
    using Interfaces;
    using System.Collections.Generic;

    public class Enemy: AIPlayer
    {
        private const int DefaultLifes = 1;

        public Enemy(IRace race, AIProvider ai)
            : base(race, ai, DefaultLifes)
        {
        }

       
    }
}
