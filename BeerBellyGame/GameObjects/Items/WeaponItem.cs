namespace BeerBellyGame.GameObjects.Items
{
    using Interfaces;

    public class WeaponItem : GameObject, IEquipable
    {
        public WeaponItem(string name, decimal purchasePrice, 
            decimal sellingPrice, double agressionValue)
        {
            this.Name = name;
            this.PurchasePrice = purchasePrice;
            this.SellingPrice = sellingPrice;
            this.AggressionValue = agressionValue;
        }


        public string Name { get; set; }

        public decimal PurchasePrice { get; set; }

        public decimal SellingPrice { get; set; }

        public bool EquipedState { get; set; }

        public double AggressionValue { get; set; }
    }
}