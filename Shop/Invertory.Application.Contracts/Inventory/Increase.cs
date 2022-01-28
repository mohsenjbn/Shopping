namespace Invertory.Application.Contracts.Inventory
{
    public class Increase
    {
        public long InventoryId { get; set; }
        public long Count { get; set; }
        public string Describtion { get; set; }

    }

}