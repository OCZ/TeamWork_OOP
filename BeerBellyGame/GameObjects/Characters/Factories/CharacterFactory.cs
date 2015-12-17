namespace BeerBellyGame.GameObjects.Characters.Factories
{
    using Interfaces;
    
    public abstract class CharacterFactory
    {
        public abstract Character Create();
        public abstract IRace GetRace();
    }
}
