namespace BeerBellyGame.GameUI
{
    using Engines;
    using Interfaces;

    public interface IGameRenderer
    {
        void Clear();

        void Draw(params IDrawable[] gameObjects);

        void ShowGameSatgeView(GameResult gameStage);
    }
}
