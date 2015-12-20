namespace BeerBellyGame.GameObjects.Items
{
    using Characters;

    public class Bullet: GameObject
    {
        public Bullet(Player player)
        {
            this.AvatarUri = AppSettings.BulletItemAvatar;
            this.IsFlaying = true;
            this.Size = new Size(AppSettings.BulletSize.Width, AppSettings.BulletSize.Height);
            this.Direction = player.LastMoveDirection;
            this.Player = player;
            this.SetPosition();
        }

        public bool IsFlaying { get; set; }
        public Direction Direction { get; set; }
        public Player Player { get; set; }

        private void SetPosition()
        {
            switch (this.Direction)
            {
                case Direction.Right:
                    this.Position = new Position(this.Player.Position.Left + this.Player.Size.Width, this.Player.Position.Top + this.Player.Size.Height / 2);
                    break;
                case Direction.Left:
                    this.Position = new Position(this.Player.Position.Left + this.Size.Width, this.Player.Position.Top + this.Player.Size.Height / 2);
                    break;
                case Direction.Up:
                    this.Position = new Position(this.Player.Position.Left + this.Player.Size.Width / 2, this.Player.Position.Top);
                    break;
                case Direction.Down:
                    this.Position = new Position(this.Player.Position.Left + this.Player.Size.Width / 2, this.Player.Position.Top + this.Player.Size.Height);
                    break;
                default:
                    this.Position = new Position(this.Player.Position.Left + this.Player.Size.Width, this.Player.Position.Top + this.Player.Size.Height / 2);
                    break;
            }

        }

        public void Move()
        {
            var top = this.Position.Top;
            var left = this.Position.Left;
            
            switch (this.Direction)
            {
                    
                case Direction.Right:
                    left = this.Position.Left + AppSettings.MopvementSpeed;
                    this.Position = new Position(left, top);
                    break;
                case Direction.Left:
                    left = this.Position.Left - AppSettings.MopvementSpeed;
                    this.Position = new Position(left, top);                   
                    break;
                case Direction.Up:
                    top = this.Position.Top - AppSettings.MopvementSpeed;
                    this.Position = new Position(left, top);                   
                    break;
                case Direction.Down:
                    top = this.Position.Top + AppSettings.MopvementSpeed;
                    this.Position = new Position(left, top);                   
                    break;
                default:
                    left = this.Position.Left + AppSettings.MopvementSpeed;
                    this.Position = new Position(left, top);
                    break;
            }
        }
    }
}
