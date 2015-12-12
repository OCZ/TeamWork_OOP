namespace BeerBellyGame.GameObjects.Items
{
    using Interfaces;

    public class BeerItem: GameObject, ICollectable
    {
        public BeerItem()
        {
            this.AvatarUri = AppSettings.BeerItemAvatar;
        }
    }
}
