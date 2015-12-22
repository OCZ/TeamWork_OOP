namespace BeerBellyGame.GameObjects.AI
{
    using Characters;
    using Items;
    using System.Collections.Generic;
    using Enums;

    public abstract class AIProvider
    {
        public Character Character { get; set; }
        public abstract Direction GetDirection(GameObject moveTo, ICollection<MazeItem> obstacles);
    }
}
