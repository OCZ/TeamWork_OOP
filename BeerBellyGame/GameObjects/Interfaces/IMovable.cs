namespace BeerBellyGame.GameObjects.Interfaces
{
    using System.Collections.Generic;
    using Items;

    public interface IMovable
    {
        ICollection<Direction> PossibleMovements(ICollection<MazeItem> objs);
    }
}
