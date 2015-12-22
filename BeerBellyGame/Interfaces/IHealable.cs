namespace BeerBellyGame.Interfaces
{
    using GameObjects.Characters;

    public interface IHealable
    {
        int RegenAmount { get; }

        void Consume(Character ch);
    }
}