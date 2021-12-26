

using _01_framework.Application;

namespace ShopiManagement.Application.Contracts.ProductCategory
{
    public interface IProductCategoryApplication
    {
        OperationResult Create(CreateProductCategory Command);
        OperationResult Edit(EditProductCategory Command);
        List<ProDuctCategoryViewModel> GetAll(ProductCategorySearchModel command);
        EditProductCategory GetDetail(long id);
    }
}
