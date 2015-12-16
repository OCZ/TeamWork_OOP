using BeerBellyGame.GameObjects.Characters;
using BeerBellyGame.GameObjects.Interfaces;

namespace BeerBellyGame.GameObjects.Items
{
    public class MediumHealthItem : GameObject, ICollectable, IHealable
    {
        public MediumHealthItem()
        {
            this.AvatarUri = AppSettings.HealthItemAvatar;
            this.RegenAmount = 20;
        }


        public int RegenAmount { get; private set; }

        public void Consume(Character ch)
        {
            ch.Health += this.RegenAmount;
        }
    }
}