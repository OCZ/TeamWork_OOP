using BeerBellyGame.GameObjects.Characters;

namespace BeerBellyGame.GameObjects.Items
{
    using Interfaces;

    public class LifeItem: CollectableItem
    {
        public LifeItem()
        {
            this.AvatarUri = AppSettings.LifeItemAvatar;
        }
        
        public override void Consume(Character ch)
        {
            ch.Life++;
        }
    }
}
