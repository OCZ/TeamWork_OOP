namespace BeerBellyGame.GameObjects.Items
{
    using Interfaces;

    public class HealthItem: GameObject, ICollectable
    {
        public HealthItem()
        {
            this.AvatarUri = AppSettings.HealthItemAvatar;
        }
    }
}
