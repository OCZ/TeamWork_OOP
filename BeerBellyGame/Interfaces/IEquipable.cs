namespace BeerBellyGame.Interfaces
{
    public interface IEquipable
    {
        string Name { get; set; }

        decimal PurchasePrice { get; set; }

        decimal SellingPrice { get; set; }

        bool EquipedState { get; set; }

    }
}