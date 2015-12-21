using System.Collections.Generic;
using BeerBellyGame.GameObjects.Interfaces;
using BeerBellyGame.GameObjects.Items;
using System;

namespace BeerBellyGame.GameObjects.Characters
{
    public class Player : Character
    {
        private const int DefaultLifes = 3;
        private const int NeedHealMinPoints = 40;

        public Player(IRace race)
            : base(DefaultLifes, race)
        {
            this.LastMoveDirection = Direction.None;
            this.Bullets = new List<Bullet>();
        }

        public override double Health
        {
            get
            {
                return base.Health;
            }
            set
            {
                if (value < NeedHealMinPoints)
                {
                    this.NeedHealEventHandler(this, new EventArgs());
                }

                base.Health = value;
            }
        }
        public Direction LastMoveDirection { get; set; }
        public List<Bullet> Bullets { get; set; }
        public event EventHandler NeedHealEventHandler;

        //public void Attack()
        //{
        //    var bullet = new Bullet
        //    {
        //        Position = new Position(this.Position.Left, this.Position.Top),
        //        Direction = this.LastMoveDirection
        //    };
        //    bullet.SetPosition(this.LastMoveDirection, this.Size, this.Position);
        // //   this.Player.Position = new Position(left + AppSettings.MopvementSpeed, top);
        //}

        
        public bool CanAttack(IDrawable e)
        {
            //TODO: Implement player's detection system which should be like enemy on left
            //TODO: or left + AgressionRange
            return false;
        }

        public List<CollectableItem> PosibleCollection(List<CollectableItem> items)
        {
            foreach (var item in items)
            {
                var direction = IntersectWith(item);
                if (direction != Direction.None)
                {
                    item.Consume(this);
                    item.IsCollected = true;
                }
            }
            items.RemoveAll(item => item.IsCollected);
            return items;
        }


    }
}
