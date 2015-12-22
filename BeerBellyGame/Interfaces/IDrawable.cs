namespace BeerBellyGame.Interfaces
{
    using GameObjects;

    public interface IDrawable
    {
        Position Position { get; set; }
        Size Size { get; set; }
        string AvatarUri { get; set; }
    }
}
