using _01_framework.Domain;

namespace InventoryManagement.Domain.InventoryAgg
{
    public class Inventory:EntityBase
    {
        public long ProductId { get; private set; }
        public double UnitPrice { get;private set; }
        public bool Instock { get; private set; }
        public List<InventoryOperation> Operations { get; private set; }

        public Inventory(long productId, double unitPrice)
        {
            ProductId = productId;
            UnitPrice = unitPrice;
            Instock = false;
        }

        public long CurrentCountInventory()
        {
            var plus=Operations.Where(p=>p.Operation).Sum(p=>p.Count);
            var minus = Operations.Where(p => !p.Operation).Sum(p => p.Count);
            return plus - minus;
        }

        public void Increase(long count,long operatorId,string describtion)
        {
            var currentcunt=CurrentCountInventory() + count;
            var Operation = new InventoryOperation(true, count, operatorId, currentcunt, describtion, 0, Id);
            Operations.Add(Operation);
            Instock = currentcunt > 0;
        }

        public void Reduce(long count, long operatorId, string describtion,long orderid)
        {
            var currentcunt = CurrentCountInventory() - count;
            var Operation = new InventoryOperation(false, count, operatorId, currentcunt, describtion, orderid, Id);
            Operations.Add(Operation);
            Instock = currentcunt > 0;


        }
    }

    public class InventoryOperation
    {
        public long Id { get; private set; }
        public bool Operation { get; private set; }
        public long Count { get; private set; }
        public long OperatorId { get; private set; }
        public DateTime CreationDate { get; private set; }
        public long CurrentCount { get; private set; }
        public string Describtion { get;private set; }
        public long OrderId { get;private set; }
        public long InventoryId { get;private set; }

        public Inventory inventory { get; private set; }

        public InventoryOperation(bool operation, long count, long operatorId, long currentCount, string describtion, long orderId, long inventoryId)
        {
            Operation = operation;
            Count = count;
            OperatorId = operatorId;
            CurrentCount = currentCount;
            Describtion = describtion;
            OrderId = orderId;
            InventoryId = inventoryId;
            CreationDate=DateTime.Now;
        }
    }

}
