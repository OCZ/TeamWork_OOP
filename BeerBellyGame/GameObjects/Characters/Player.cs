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

        public bool CanAttack(IDrawable e)
        {
            //TODO: Implement player's detection system which should be like enemy on left
            //TODO: or left + AgressionRange
            return false;
        }
    }
}
