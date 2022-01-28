namespace Invertory.Application.Contracts.Inventory
{
    public class Reduce
    {
        public long ProductId { get; set; }
        public long Count { get; set; }
        public long Describtion { get; set; }
        public long OrderId { get; set; }
    }

}