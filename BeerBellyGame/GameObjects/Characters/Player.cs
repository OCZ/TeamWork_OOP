using System.Collections.Generic;
using BeerBellyGame.GameObjects.Interfaces;
using BeerBellyGame.GameObjects.Items;

namespace BeerBellyGame.GameObjects.Characters
{
    public class Player : Character
    {
        private const int DefaultLifes = 3;

        public Player(IRace race)
            : base(DefaultLifes, race)
        {
        }

        public bool CanAttack(IDrawable e)
        {
            //TODO: Implement player's detection system which should be like enemy on left
            //TODO: or left + AgressionRange
            return false;
        }

        public List<CollectableItem> PosibleCollection(List<CollectableItem> items)
        {
            foreach (var item in items)
            {
                var direction = IntersectWith(item);
                if (direction != Direction.None)
                {
                    var i = 0;
                    item.Consume(this);
                    item.IsCollected = true;
                    // items.Remove(item);
                }
            }
            items.RemoveAll(item => item.IsCollected);
            return items;
        }
    }
}
