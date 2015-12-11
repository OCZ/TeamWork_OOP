namespace BeerBellyGame.GameObjects.Interfaces
{
    public interface IDrawable
    {
        Position Position { get; set; }
        Size Size { get; set; }
        string AvatarUri { get; set; }
    }
}
