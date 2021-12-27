using _01_framework.Domain;
using ShopiManagement.Application.Contracts.ProductCategory;

using System.Linq.Expressions;


namespace Sh.Domain.ProductCategoryAgg
{
    public interface IProductCategoryRepository:IRepository<long,ProductCategory>
    {

        List<ProDuctCategoryViewModel> Search(ProductCategorySearchModel searchmodel);
        EditProductCategory GetDatail(long id);
    }
}
