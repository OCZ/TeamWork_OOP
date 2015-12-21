namespace BeerBellyGame.GameUI
{
    using Engines;
    using GameObjects.Interfaces;

    public interface IGameRenderer
    {
        void Clear();

        void Draw(params IDrawable[] gameObjects);

        void ShowGameSatgeView(GameStage gameStage);
    }
}
