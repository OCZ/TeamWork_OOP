namespace BeerBellyGame.GameObjects.Characters
{
    using BeerBellyGame.GameObjects.AI;
    using BeerBellyGame.GameObjects.Items;
    using Interfaces;
    using System.Collections.Generic;

    public class Friend : AIPlayer
    {
        private const int DefaultLifes = 3;

        public Friend(IRace race, AIProvider ai)
            : base(race, ai, DefaultLifes)
        {
        }
    }
}
