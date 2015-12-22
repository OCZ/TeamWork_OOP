namespace BeerBellyGame.GameObjects.Items
{
    using Characters;

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
