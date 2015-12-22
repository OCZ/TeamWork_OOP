namespace BeerBellyGame.GameObjects
{
    using Interfaces;
    using Enums;


    public abstract class GameObject: IDrawable
    {
        protected GameObject()
        {
        }
        public Position Position { get; set; }
        public Size Size { get; set; }
        public string AvatarUri { get; set; }
        public Direction IntersectWith(IDrawable obj)
        {
            if ((this.Position.Left > obj.Position.Left && this.Position.Left < obj.Position.Left + obj.Size.Width)
                || (this.Position.Left + this.Size.Width > obj.Position.Left && this.Position.Left + this.Size.Width < obj.Position.Left + obj.Size.Width)
                || (this.Position.Left == obj.Position.Left && this.Position.Left + this.Size.Width == obj.Position.Left + obj.Size.Width))
            {
                if (this.Position.Top + this.Size.Height >= obj.Position.Top && this.Position.Top + this.Size.Height < obj.Position.Top + obj.Size.Height)
                {
                    return Direction.Down;
                }

                if (this.Position.Top <= obj.Position.Top + obj.Size.Height && this.Position.Top > obj.Position.Top)
                {
                    return Direction.Up;
                }
            }

            if ((this.Position.Top > obj.Position.Top && this.Position.Top < obj.Position.Top + obj.Size.Height)
                || (this.Position.Top + this.Size.Height > obj.Position.Top && this.Position.Top + this.Size.Height < obj.Position.Top + obj.Size.Height)
                || (this.Position.Top == obj.Position.Top && this.Position.Top + this.Size.Height == obj.Position.Top + obj.Size.Height))
            {
                if (this.Position.Left <= obj.Position.Left + obj.Size.Width && this.Position.Left > obj.Position.Left)
                {
                    return Direction.Left;
                }

                if (this.Position.Left + this.Size.Width >= obj.Position.Left && this.Position.Left + this.Size.Width < obj.Position.Left + obj.Size.Width)
                {
                    return Direction.Right;
                }
            }

            return Direction.None;
        }
    }
}
