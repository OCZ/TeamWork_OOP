namespace BeerBellyGame.GameObjects.Items
{
    using Interfaces;
    using Characters;

    public class SmallHealthItem : CollectableItem, IHealable
    {
        public SmallHealthItem()
        {
            this.AvatarUri = AppSettings.HealthItemAvatar;
            this.RegenAmount = 10;
        }

        public int RegenAmount { get; private set; }

        public override void Consume(Character ch)
        {
            ch.Health += this.RegenAmount;
        }
    }
}