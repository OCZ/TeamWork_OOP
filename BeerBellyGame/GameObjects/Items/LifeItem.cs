using BeerBellyGame.GameObjects.Characters;

namespace BeerBellyGame.GameObjects.Items
{
    using Interfaces;

    public class LifeItem: GameObject, ICollectable
    {
        public LifeItem()
        {
            this.AvatarUri = AppSettings.LifeItemAvatar;
        }
        
        public void Consume(Character ch)
        {
            ch.Life++;
        }
    }
}
