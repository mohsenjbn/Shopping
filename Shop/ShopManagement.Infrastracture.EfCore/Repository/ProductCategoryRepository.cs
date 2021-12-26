

using Sh.Domain.ProductCategoryAgg;
using ShopiManagement.Application.Contracts.ProductCategory;
using System.Linq.Expressions;

namespace ShopManagement.Infrastracture.EfCore.Repository
{
    public class ProductCategoryRepository : IProductCategoryRepository
    {
        private readonly ShopContext _context;
        public ProductCategoryRepository(ShopContext context)
        {
            _context=context;
        }
        public void Create(ProductCategory enitry)
        {
            _context.productCategories.Add(enitry);
        }

        public bool Exist(Expression<Func<ProductCategory, bool>> expression)
        {
            return _context.productCategories.Any(expression);
        }

        public ProductCategory Get(long id)
        {
            return _context.productCategories.Find(id);
        }

        public List<ProductCategory> GetAll()
        {
          return  _context.productCategories.ToList();
        }

        public EditProductCategory GetDatail(long id)
        {
            return _context.productCategories.Select(x => new EditProductCategory()
            {
                Id = x.Id,
                Name=x.Name,
                Picture=x.Picture,
                PictureAlt=x.PictureAlt,
                PictureTitle=x.PictureTitle,
                Describtion=x.Describtion,
                MetaDescribtion=x.MetaDescribtion,
                KeyWords=x.KeyWords,
                Slug=x.Slug,

            
            }
            
            ).FirstOrDefault(x => x.Id == id);
        }

        public void save()
        {
            _context.SaveChanges();
        }

        public List<ProDuctCategoryViewModel> Search(ProductCategorySearchModel searchmodel)
        {
            var query = _context.productCategories.Select(p => new ProDuctCategoryViewModel()
            {
                Name = p.Name,
                picture = p.Picture,
                Id = p.Id,
                CreationDate = p.CreationDate.ToString()
            }); 

            if(!string.IsNullOrWhiteSpace(searchmodel.Name))
                query=query.Where(p=>p.Name.Contains(searchmodel.Name));

            return query.OrderByDescending(p=>p.Id).ToList();
        }
    }
}
