namespace BeerBellyGame.GameObjects.Characters
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Enums;
    using Interfaces;
    using Items;
    
    public class Player : Character
    {
        public Player(IRace race)
           : base(AppSettings.PlayerDefaultLifes, race)
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
                if (value < AppSettings.PlayerNeedHealMinPoints)
                {
                    this.NeedHealEventHandler(this, new EventArgs());
                }

                base.Health = value;
            }
        }
        public Direction LastMoveDirection { get; set; }
        public List<Bullet> Bullets { get; set; }
        public event EventHandler NeedHealEventHandler;
        
        public List<CollectableItem> PosibleCollection(List<CollectableItem> items)
        {
            foreach (var item in from item in items let direction = IntersectWith(item) where direction != Direction.None select item)
            {
                item.Consume(this);
                item.IsCollected = true;
            }
            items.RemoveAll(item => item.IsCollected);
            return items;
        }
    }
}
