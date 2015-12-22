namespace BeerBellyGame.GameObjects.Characters
{
    using AI;
    using Items;
    using System.Collections.Generic;
    using Enums;
    using Interfaces;

    public abstract class AIPlayer : Character, IAIMovement
    {
        protected AIProvider AI;

        protected AIPlayer(IRace race, AIProvider ai, int DefaultLifes)
            : base(DefaultLifes, race)
        {
            this.AI = ai;
            this.AI.Character = this;
        }

        public virtual void Move(GameObject moveTo, ICollection<MazeItem> obstacles)
        {
            var left = this.Position.Left;
            var top = this.Position.Top;

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
