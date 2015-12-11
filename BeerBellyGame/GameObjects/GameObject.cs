namespace BeerBellyGame.GameObjects
{
    using Interfaces;

    public abstract class GameObject: IDrawable
    {
        protected GameObject()
        {
            
        }
        public Position Position { get; set; }
        public Size Size { get; set; }
        public string AvatarUri { get; set; }
    }
}
