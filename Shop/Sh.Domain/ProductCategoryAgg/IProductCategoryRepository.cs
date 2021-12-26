using ShopiManagement.Application.Contracts.ProductCategory;

using System.Linq.Expressions;


namespace Sh.Domain.ProductCategoryAgg
{
    public interface IProductCategoryRepository
    {
        void Create(ProductCategory enitry);
        ProductCategory Get(long id);
        List<ProductCategory> GetAll();
        bool Exist(Expression<Func<ProductCategory,bool>> expression);
        void save();

        List<ProDuctCategoryViewModel> Search(ProductCategorySearchModel searchmodel);
        EditProductCategory GetDatail(long id);
    }
}
