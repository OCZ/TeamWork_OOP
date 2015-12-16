namespace BeerBellyGame.GameObjects.AI
{
    using BeerBellyGame.GameObjects.Characters;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Items;

    public class TargetCharacterAIProvider : AIProvider
    {
        public override Direction GetDirection(GameObject moveTo, ICollection<MazeItem> obstacles)
        {
            List<Direction> possibles = (List<Direction>)this.Character.PossibleMovements(obstacles);

            if (moveTo.Position.Left < this.Character.Position.Left && possibles.Contains(Direction.left))
            {
                return Direction.left;
            }
            else if (moveTo.Position.Left > this.Character.Position.Left && possibles.Contains(Direction.right))
            {
                return Direction.right;
            }

            if (moveTo.Position.Top < this.Character.Position.Top && possibles.Contains(Direction.up))
            {
                return Direction.up;
            }
            else if (moveTo.Position.Top > this.Character.Position.Top && possibles.Contains(Direction.down))
            {
                return Direction.down;
            }

            return Direction.none;
        }
    }
}
