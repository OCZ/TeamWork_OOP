using BeerBellyGame.GameObjects.Characters;

namespace BeerBellyGame.GameObjects.Interfaces
{
    public interface IHealable
    {
        int RegenAmount { get; }

        void Consume(Character ch);
    }
}