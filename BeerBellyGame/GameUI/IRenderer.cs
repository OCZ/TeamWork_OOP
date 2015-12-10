namespace BeerBellyGame.GameUI
{
    using GameObjects.Interfaces;

    public interface IGameRenderer
    {
        void Clear();

        void Draw(params IDrawable[] gameObjects);
    }
}
