using BeerBellyGame.GameObjects.Interfaces;

namespace BeerBellyGame.GameObjects.Items
{
    public class SpyToolItem: GameObject, IEquipable
    {
        public SpyToolItem(string name, decimal purchasePrice, decimal sellingPrice, int agressionRange)
        {
            this.Name = name;
            this.PurchasePrice = purchasePrice;
            this.SellingPrice = sellingPrice;
            this.AgressionRange = agressionRange;
        }


        public string Name { get; set; }

        public decimal PurchasePrice { get; set; }

        public decimal SellingPrice { get; set; }

        public bool EquipedState { get; set; }

        public int AgressionRange { get; set; }
    }
}