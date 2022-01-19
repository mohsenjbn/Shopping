using _01_ShopQuery.Contracts.ProductCategory;
using ShopManagement.Infrastracture.EfCore;

namespace _01_ShopQuery.Query
{
    public class ProductCategoryQuery : IProductCategoryQuery
    {
        private readonly ShopContext _shopContext;

        public ProductCategoryQuery(ShopContext shopContext)
        {
            _shopContext = shopContext;
        }

        public List<ProductCategoryQueryModel> GetAllCategories()
        {
            return _shopContext.productCategories.Select(c => new ProductCategoryQueryModel
            {
                Id = c.Id,
                Name = c.Name,
                Picture=c.Picture,
                PictureAlt=c.PictureAlt,
                PictureTitle=c.PictureTitle,
                Slug=c.Slug,


            }).OrderByDescending(p=>p.Id).Take(3).ToList();
        }
    }
}
