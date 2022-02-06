using _0_Framework.Application;
using _01_ShopQuery.Contracts.Product;
using DiscontManagement.Infrastracture.EfCore;
using InventoryManagement.Infrastructure.EfCore;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Infrastracture.EfCore;

namespace _01_ShopQuery.Query
{
    public class ProductQuery : IProductQuery
    {
        private readonly ShopContext _shopContext;
        private readonly DiscountContext _discountContext;
        private readonly InventoryContext _inventoryContext;

        public ProductQuery(ShopContext shopContext, DiscountContext discountContext, InventoryContext inventoryContext)
        {
            _shopContext = shopContext;
            _discountContext = discountContext;
            _inventoryContext = inventoryContext;
        }

        public List<ProductQueryViewModel> LatestArrivals()
        {
            var inventoryProduct = _inventoryContext.Inventory.Select(p => new { p.ProductId, p.UnitPrice }).ToList();
            var Discount = _discountContext.CustomerDiscounts.Where(p => p.StartDate < DateTime.Now && p.EndDate > DateTime.Now)
                .Select(c => new { c.ProductId, c.DiscountRate }).ToList();
            var Products = _shopContext.Products.Include(p => p.ProductCategory).Select(p => new ProductQueryViewModel
            {
                Id = p.Id,
                Category = p.ProductCategory.Name,
                Name = p.Name,
                Picture = p.Picture,
                PictureAlt = p.PictureAlt,
                PictureTitle = p.PictureTitle,
                Slug = p.Slug,


            }).OrderByDescending(p => p.Id).Take(6).AsNoTracking().ToList(); ;

            foreach (var Product in Products)
            {
                var inventory = inventoryProduct.FirstOrDefault(p => p.ProductId == Product.Id);
                if (inventory != null)
                {
                    var price = inventory.UnitPrice;
                    Product.UnitPrice = price.ToMoney();

                    var ProductDiscount = Discount.FirstOrDefault(p => p.ProductId == Product.Id);
                    if (ProductDiscount != null)
                    {
                        var DiscontRate = ProductDiscount.DiscountRate;
                        Product.DiscountRate = DiscontRate;
                        Product.Discount = DiscontRate > 0;
                        var PriceWithDiscount = Math.Round((price * DiscontRate) / 100);
                        Product.PriceWithDiscoint = (price - PriceWithDiscount).ToMoney();
                    }

                }

            }

            return Products;
        }
    }
}
