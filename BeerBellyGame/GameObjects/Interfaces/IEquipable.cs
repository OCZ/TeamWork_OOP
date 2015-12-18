namespace BeerBellyGame.GameObjects.Interfaces
{
    public interface IEquipable
    {
        string Name { get; set; }

        //Not sure if neccessary
        //string Description { get; set; }

        decimal PurchasePrice { get; set; }

        decimal SellingPrice { get; set; }

        //If the item is equiped => Applies it's effects
        bool EquipedState { get; set; }

    }
}