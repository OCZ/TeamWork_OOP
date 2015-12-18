namespace BeerBellyGame.GameObjects.Items
{
    using Characters;

    public abstract class CollectableItem: GameObject
    {
        protected CollectableItem()
        {
            this.IsCollected = false;
        }
        public bool IsCollected { get; set; }
        public abstract void Consume(Character ch);

    }
}
