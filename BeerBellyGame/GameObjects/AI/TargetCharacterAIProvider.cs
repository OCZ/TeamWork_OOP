namespace BeerBellyGame.GameObjects.AI
{
    using System.Collections.Generic;
    using Enums;
    using Items;
    
    public class TargetCharacterAIProvider : AIProvider
    {
        public override Direction GetDirection(GameObject moveTo, ICollection<MazeItem> obstacles)
        {
            List<Direction> possibles = (List<Direction>)this.Character.PossibleMovements(obstacles);

            if (moveTo.Position.Left < this.Character.Position.Left && possibles.Contains(Direction.Left))
            {
                return Direction.Left;
            }
            else if (moveTo.Position.Left > this.Character.Position.Left && possibles.Contains(Direction.Right))
            {
                return Direction.Right;
            }

            if (moveTo.Position.Top < this.Character.Position.Top && possibles.Contains(Direction.Up))
            {
                return Direction.Up;
            }
            else if (moveTo.Position.Top > this.Character.Position.Top && possibles.Contains(Direction.Down))
            {
                return Direction.Down;
            }

            return Direction.None;
        }
    }
}
