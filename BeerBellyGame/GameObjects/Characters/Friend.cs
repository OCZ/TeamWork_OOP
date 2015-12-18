namespace BeerBellyGame.GameObjects.Characters
{
    using BeerBellyGame.GameObjects.AI;
    using Interfaces;
   
    public class Friend : AIPlayer
    {
        private const int DefaultLifes = 3;

        public Friend(IRace race, AIProvider ai)
            : base(race, ai, DefaultLifes)
        {
        }
    }
}
