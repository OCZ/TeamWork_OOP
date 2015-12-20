using BeerBellyGame.GameObjects.Characters;

namespace BeerBellyGame.GameObjects.Items
{
   public class BeerItem: CollectableItem
    {
        public BeerItem()
        {
            this.AvatarUri = AppSettings.BeerItemAvatar;
        }

        public override void Consume(Character ch)
        {
            ch.BeerBelly += 10;
        }
    }
}
