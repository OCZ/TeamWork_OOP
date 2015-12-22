namespace BeerBellyGame.Interfaces
{
    using System.Collections.Generic;
    using GameObjects;
    using GameObjects.Items;

    public interface IAIMovement
    {
        void Move(GameObject moveTo, ICollection<MazeItem> obstacles);
    }
}
