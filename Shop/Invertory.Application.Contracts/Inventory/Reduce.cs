namespace Invertory.Application.Contracts.Inventory
{
    public class Reduce
    {
        public long InventoryId { get; set; }
        public long ProductId { get; set; }
        public long Count { get; set; }
        public string Describtion { get; set; }
        public long OrderId { get; set; }
    }

}