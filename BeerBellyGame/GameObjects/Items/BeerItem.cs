using BeerBellyGame.GameObjects.Characters;

namespace BeerBellyGame.GameObjects.Items
{
    using Interfaces;

    public class BeerItem: GameObject, ICollectable
    {
        public BeerItem()
        {
            this.AvatarUri = AppSettings.BeerItemAvatar;
        }

        public void Consume(Character ch)
        {
            ch.BeerBelly += 10;
        }
    }
}
