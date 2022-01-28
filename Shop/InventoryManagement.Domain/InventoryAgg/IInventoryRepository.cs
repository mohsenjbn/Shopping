using _01_framework.Domain;
using Invertory.Application.Contracts.Inventory;

namespace InventoryManagement.Domain.InventoryAgg
{
    public interface  IInventoryRepository:IRepository<long,Inventory>
    {
        Inventory GetBy(long ProductId);
        List<InventoryViewModel> GetAll(InventorySeacrModel seacrodel);
        UpdateInventory GetDetails(long id);
    }
}
