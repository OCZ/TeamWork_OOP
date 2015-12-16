using BeerBellyGame.GameObjects.AI;
using BeerBellyGame.GameObjects.Interfaces;
using BeerBellyGame.GameObjects.Items;
using System.Collections.Generic;

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
                case Direction.Left:
                    left = this.Position.Left - AppSettings.MopvementSpeed;
                    break;
                case Direction.Right:
                    left = this.Position.Left + AppSettings.MopvementSpeed;
                    break;
                case Direction.Up:
                    top = this.Position.Top - AppSettings.MopvementSpeed;
                    break;
                case Direction.Down:
                    top = this.Position.Top + AppSettings.MopvementSpeed;
                    break;
            }

            this.Position = new Position(left, top);
        }
    }
}
