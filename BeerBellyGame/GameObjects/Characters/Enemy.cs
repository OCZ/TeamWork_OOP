namespace BeerBellyGame.GameObjects.Characters
{
    using Interfaces;

    public class Enemy: Character
    {
        private const int DefaultLifes = 1;
        
        public Enemy(IRace race)
            : base(DefaultLifes, race)
        {
        }
    }
}
