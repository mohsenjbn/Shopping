
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopiManagement.Application.Contracts.ProductCategory;

namespace ServiceHost.Areas.Adminstarator.Pages.Shop.PoductCategory
{
    public class IndexModel : PageModel
    {
        public ProductCategorySearchModel Search { get ; set; }

        public List<ProDuctCategoryViewModel> ProductCategories { get; set; }
        private readonly IProductCategoryApplication _productCategoryApplication;
        public IndexModel(IProductCategoryApplication productCategoryApplication)
        {
            _productCategoryApplication = productCategoryApplication;
        }
        public void OnGet(ProductCategorySearchModel search)
        {
            ProductCategories=_productCategoryApplication.GetAll(search);
        }
    }
}
