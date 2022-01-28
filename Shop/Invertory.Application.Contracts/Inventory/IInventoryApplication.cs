using _01_framework.Application;

namespace Invertory.Application.Contracts.Inventory
{
    public interface IInventoryApplication
    {

        OperationResult Create(CreateInventory command);
        OperationResult Edit(UpdateInventory command);
        List<InventoryViewModel> GetAll(InventorySeacrModel seacrodel);
        UpdateInventory GetDetails(long id);
        OperationResult Increase(Increase command);
        OperationResult Reduce(Reduce command);
        OperationResult Reduce(List<Reduce> command);




    }
}
