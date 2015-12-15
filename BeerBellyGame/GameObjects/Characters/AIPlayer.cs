using BeerBellyGame.GameObjects.AI;
using BeerBellyGame.GameObjects.Interfaces;
using BeerBellyGame.GameObjects.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerBellyGame.GameObjects.Characters
{
    public abstract class AIPlayer : Character, IAIMovement
    {
        private AIProvider AI;

        public AIPlayer(IRace race, AIProvider ai, int DefaultLifes)
            : base(DefaultLifes, race)
        {
            this.AI = ai;
            this.AI.Character = this;
        }

        public void Move(GameObject moveTo, ICollection<MazeItem> obstacles)
        {
            int left = this.Position.Left;
            int top = this.Position.Top;

            switch (this.AI.GetDirection(moveTo, obstacles))
            {
                case Direction.left:
                    left = this.Position.Left - AppSettings.MopvementSpeed;
                    break;
                case Direction.right:
                    left = this.Position.Left + AppSettings.MopvementSpeed;
                    break;
                case Direction.up:
                    top = this.Position.Top - AppSettings.MopvementSpeed;
                    break;
                case Direction.down:
                    top = this.Position.Top + AppSettings.MopvementSpeed;
                    break;
            }

            this.Position = new Position(left, top);
        }
    }
}
