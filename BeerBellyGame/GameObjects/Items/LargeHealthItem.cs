namespace BeerBellyGame.GameObjects.Items
{
    using Interfaces;

    using Characters;

    public class LargeHealthItem : CollectableItem, IHealable
    {
        public LargeHealthItem()
        {
            this.AvatarUri = AppSettings.HealthItemAvatar;
            this.RegenAmount = 30;
        }

        public int RegenAmount { get; private set; }

        public override void Consume(Character ch)
        {
            ch.Health += this.RegenAmount;
        }
    }
}