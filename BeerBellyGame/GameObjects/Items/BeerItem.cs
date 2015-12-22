namespace BeerBellyGame.GameObjects.Items
{
   using Characters;
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
