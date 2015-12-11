namespace BeerBellyGame.GameObjects.Characters
{
    using Interfaces;

    public class Friend: Character
    {
        private const int DefaultLifes = 3;

        public Friend( IRace race)
            : base(DefaultLifes, race)
        {
        }
    }
}
