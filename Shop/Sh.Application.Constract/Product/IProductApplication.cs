

using _01_framework.Application;

namespace ShopManagement.Application.Contracts.Product
{
    public interface IProductApplication
    {
        OperationResult Create(CreateProduct command);
        OperationResult Edit(EditProduct command);
        OperationResult IsInStock(long id);
        OperationResult NotIsStock(long id);
        EditProduct GetDetails(long id);
        List<ProductViewModel> GetAll(SearchModelProduct search);
    }
}
