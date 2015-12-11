namespace BeerBellyGame.GameObjects.Characters
{
    using Interfaces;

    public class Player: Character
    {
        private const int DefaultLifes = 3;
        public Player(IRace race)
            : base(DefaultLifes, race)
        {
        }
    }
}
