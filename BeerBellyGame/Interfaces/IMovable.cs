namespace BeerBellyGame.Interfaces
{
    using System.Collections.Generic;
    using Enums;
    using GameObjects.Items;

    public interface IMovable
    {
        ICollection<Direction> PossibleMovements(ICollection<MazeItem> objs);
    }
}
