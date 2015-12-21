namespace BeerBellyGame.GameObjects.Characters
{
    using BeerBellyGame.GameObjects.AI;
using Interfaces;
using System;
using System.Collections.Generic;
   
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
