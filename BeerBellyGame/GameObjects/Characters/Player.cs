namespace BeerBellyGame.GameObjects.Characters
{
    using System.Collections.Generic;
    using Interfaces;
    using Items;

    public class Player: Character
    {
        private const int DefaultLifes = 3;
        public Player(IRace race)
            : base(DefaultLifes, race)
        {
        }

        public List<CollectableItem> PosibleCollection(List<CollectableItem> items)
        {
            foreach (var item in items)
            {
                var direction = this.IntersectWith(item);
                if (direction != Direction.None)
                {
                    var i = 0;
                    item.Consume(this);
                    item.IsCollected = true;
                   // items.Remove(item);
                }
            }
            items.RemoveAll(item => item.IsCollected == true);
            return items;
        }

       
    }   
}
