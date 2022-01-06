using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Sh.Domain.ProductCategoryAgg;
using ShopiManagement.Application.Contracts.ProductCategory;
using ShopManagement.Application;
using ShopManagement.Application.Contracts.Product;
using ShopManagement.Domain.ProductAgg;
using ShopManagement.Infrastracture.EfCore;
using ShopManagement.Infrastracture.EfCore.Repository;

namespace ShopManagement.Configuration
{
    public class ShopManagementBootstrapper
    {
        public static void Configure(IServiceCollection service,string ConnecttionString)
        {
            service.AddTransient<IProductCategoryApplication, ProductCategoryApplication>();
            service.AddTransient<IProductCategoryRepository,ProductCategoryRepository>();
            service.AddTransient<IProductApplication, ProductApplication>();
            service.AddTransient<IProductRepository,ProductRepository>();

            service.AddDbContext<ShopContext>(x => x.UseSqlServer(ConnecttionString));


        }
    }
}