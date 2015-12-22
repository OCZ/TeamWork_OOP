namespace BeerBellyGame.GameObjects.Characters
{
    using System;
    using System.Collections.Generic;

     using AI;
     using Enums;
     using Interfaces;

    public class Friend : AIPlayer
    {
        private const int DefaultLifes = 3;
        private const int HealPoints = 50;
        public Player FriendToHeal { get; private set; }
        private bool FriendNeedHeal;
        private AIProvider HealAI;
        private AIProvider NormalAI;

        public Friend(IRace race, AIProvider ai, AIProvider healAI)
            : base(race, ai, DefaultLifes)
        {
            this.HealAI = healAI;
            this.NormalAI = ai;
        }

        public override double Health
        {
            get
            {
                return base.Health;
            }
            set
            {
                if (value <= 0)
                {
                    if (this.Life == 0)
                    {
                        this.IsAlive = false;
                    }
                    else
                    {
                        this.Life--;
                        this.Health = DeffHealth;
                    }
                }
                else
                {
                    base.Health = value;
                }
            }
        }

        public void AddFrined(Player f)
        {
            this.FriendToHeal = f;
            f.NeedHealEventHandler += MoveToFriend;
        }
        public void RemoveFrined(Player f)
        {
            this.FriendToHeal = null;
            f.NeedHealEventHandler -= MoveToFriend;
        }

        public void MoveToFriend(object sender, EventArgs args)
        {
            Player p = sender as Player;
            if (p != null)
            {
                this.FriendNeedHeal = true;
                base.AI = this.HealAI;
                base.AI.Character = this;
            }
        }

        public override void Move(GameObject moveTo, ICollection<Items.MazeItem> obstacles)
        {
            base.Move(moveTo, obstacles);
            if (this.FriendNeedHeal)
            {
                if (this.IntersectWith(this.FriendToHeal) != Direction.None)
                {
                    this.FriendToHeal.Health += Math.Min(HealPoints, this.Health);
                    this.Health -= Math.Min(HealPoints, this.Health);
                    if (this.Health <= 0)
                    {
                        this.IsAlive = false;
                    }

                    this.FriendNeedHeal = false;
                    base.AI = this.NormalAI;
                    base.AI.Character = this;
                }
            }
        }
    }
}
