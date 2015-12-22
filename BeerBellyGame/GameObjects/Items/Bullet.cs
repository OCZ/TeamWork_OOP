namespace BeerBellyGame.GameObjects.Items
{
    using System.Collections.Generic;
    using Interfaces;
    using Characters;
    using Enums;

    public class Bullet: GameObject, IMovable
    {
        private int _leftRangeBorder ;
        private int _rightRangeBorder;
        private int _topRangeBorder;
        private int _bottomRangeBorder;
        public Bullet(Player player)
        {
            this.AvatarUri = AppSettings.BulletItemAvatar;
            this.IsFlaying = true;
            this.Size = new Size(AppSettings.BulletSize.Width, AppSettings.BulletSize.Height);
            this.Direction = player.LastMoveDirection;
            this.Player = player;
            this.Range = player.AggressionRange;
            this.Damage = player.Aggression;
            this.SetPosition();
            this.SetRangeBorders();
        }

        public bool IsFlaying { get; set; }
        public Direction Direction { get; set; }
        public Player Player { get; set; }
        public int Range { get; set; }
        public double Damage { get; set; }
       // public Position RangeLimitPosition { get; set; }
        

        private void SetPosition()
        {
            //var rangeLeft = this.Position.Left;
            //var rangeTop = this.Position.Top;

            switch (this.Direction)
            {
                 
                case Direction.Right:
                    this.Position = new Position(this.Player.Position.Left + this.Player.Size.Width, this.Player.Position.Top + this.Player.Size.Height / 2);
                  //  rangeLeft += this.Range;
                 //   this.RangeLimitPosition = new Position(rangeLeft, rangeTop);
                    break;
                case Direction.Left:
                    this.Position = new Position(this.Player.Position.Left + this.Size.Width, this.Player.Position.Top + this.Player.Size.Height / 2);
                    //rangeLeft -= this.Range;
                   // this.RangeLimitPosition = new Position(rangeLeft, rangeTop);
                    break;
                case Direction.Up:
                    this.Position = new Position(this.Player.Position.Left + this.Player.Size.Width / 2, this.Player.Position.Top);
                    //rangeTop += this.Range;
                   // this.RangeLimitPosition = new Position(rangeLeft, rangeTop);
                    break;
                case Direction.Down:
                    this.Position = new Position(this.Player.Position.Left + this.Player.Size.Width / 2, this.Player.Position.Top + this.Player.Size.Height);
                    //rangeTop -= this.Range;
                   // this.RangeLimitPosition = new Position(rangeLeft, rangeTop);
                    break;
                default:
                    this.Position = new Position(this.Player.Position.Left + this.Player.Size.Width, this.Player.Position.Top + this.Player.Size.Height / 2);
                    //rangeLeft += this.Range;
                   // this.RangeLimitPosition = new Position(rangeLeft, rangeTop);
                    break;
            }
            
        }

       

        public List<Enemy> Move(List<MazeItem> maze, List<Enemy> enemies)
        {
            var top = this.Position.Top;
            var left = this.Position.Left;
            var enemiesLeft = enemies;
            var possibleMovements = this.PossibleMovements(maze);
     
            switch (this.Direction)
            {
                case Direction.Right:
                    if (possibleMovements.Contains(Direction.Right))
                    {
                        left = this.Position.Left + AppSettings.MopvementSpeed;
                        if (this.CheckBulletIsInRange(left, top))
                        {
                            enemiesLeft = this.PossibleKills(enemiesLeft);
                            this.Position = new Position(left, top);
                        }
                    }
                    else
                    {
                        this.IsFlaying = false;
                    }
                    break;
                case Direction.Left:
                    if (possibleMovements.Contains(Direction.Left))
                    {
                        left = this.Position.Left - AppSettings.MopvementSpeed;
                        if (this.CheckBulletIsInRange(left, top))
                        {
                            enemiesLeft = this.PossibleKills(enemiesLeft);
                            this.Position = new Position(left, top); 
                        }
                    }
                    else
                    {
                        this.IsFlaying = false;
                    }              
                    break;
                case Direction.Up:
                    if (possibleMovements.Contains(Direction.Up))
                    {
                        top = this.Position.Top - AppSettings.MopvementSpeed;
                        if (this.CheckBulletIsInRange(left, top))
                        {
                            enemiesLeft = this.PossibleKills(enemiesLeft);
                            this.Position = new Position(left, top);
                        }
                    }
                    else
                    {
                        this.IsFlaying = false;
                    }
                    break;
                case Direction.Down:
                    if (possibleMovements.Contains(Direction.Down))
                    {
                        top = this.Position.Top + AppSettings.MopvementSpeed;
                        if (this.CheckBulletIsInRange(left, top))
                        {
                            enemiesLeft = this.PossibleKills(enemiesLeft);
                            this.Position = new Position(left, top);     
                        }    
                    }
                    else
                    {
                        this.IsFlaying = false;
                    }
                    break;
                default:
                    if (possibleMovements.Contains(Direction.Right))
                    {
                        left = this.Position.Left + AppSettings.MopvementSpeed;
                        if (this.CheckBulletIsInRange(left, top))
                        {
                            enemiesLeft = this.PossibleKills(enemiesLeft);
                            this.Position = new Position(left, top);
                        }  
                    }
                    else
                    {
                        this.IsFlaying = false;
                    }
                    break;
            }
            return enemiesLeft;
        }

        private bool CheckBulletIsInRange(int left, int top)
        {
            if (left > this._leftRangeBorder 
                && left < this._rightRangeBorder
                && top > this._topRangeBorder
                && top < this._bottomRangeBorder)
            {
                return true;
            }
            this.IsFlaying = false;
            return false;
        }

        private List<Enemy> PossibleKills(List<Enemy> enemies)
        {
            foreach (var enemy in enemies)
            {
                var direction = IntersectWith(enemy);
                if (direction != Direction.None)
                {
                    enemy.Health -= this.Damage;
                    if (enemy.Health <= 0)
                    {
                        enemy.Life --;
                    }
                    if (enemy.Life <=0)
                    {
                        enemy.IsAlive = false;    
                    }
                    this.IsFlaying = false;
                }
            }
            enemies.RemoveAll(enemy => enemy.IsAlive == false);
            return enemies;
        }
        private void SetRangeBorders()
        {
            this._rightRangeBorder = this.Position.Left + this.Range;
            this._leftRangeBorder = this.Position.Left - this.Range;
            this._topRangeBorder = this.Position.Top - this.Range;
            this._bottomRangeBorder = this.Position.Top + this.Range;
            if (this._rightRangeBorder > AppSettings.MapPosition.Left + AppSettings.MapWidth)
            {
                this._rightRangeBorder = AppSettings.MapPosition.Left + AppSettings.MapWidth;
            }
            if (this._leftRangeBorder < AppSettings.MapPosition.Left)
            {
                this._leftRangeBorder = AppSettings.MapPosition.Left;
            }
            if (this._topRangeBorder < AppSettings.MapPosition.Top)
            {
                this._topRangeBorder = AppSettings.MapPosition.Top;
            }
            if (this._bottomRangeBorder > AppSettings.MapPosition.Top + AppSettings.MapHeight)
            {
                this._bottomRangeBorder = AppSettings.MapPosition.Top + AppSettings.MapHeight;
            }
        }

        public ICollection<Direction> PossibleMovements(ICollection<MazeItem> objs)
        {
            var directions = new List<Direction>(){
                Direction.Down,
                Direction.Left,
                Direction.Right,
                Direction.Up
            };

            foreach (var o in objs)
            {
                directions.Remove(this.IntersectWith(o));
            }

            return directions;
        }
    }
}
