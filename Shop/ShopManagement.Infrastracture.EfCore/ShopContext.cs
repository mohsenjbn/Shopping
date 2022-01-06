﻿
using Microsoft.EntityFrameworkCore;
using Sh.Domain.ProductCategoryAgg;
using ShopManagement.Domain.ProductAgg;
using ShopManagement.Infrastracture.EfCore.Mapping;

namespace ShopManagement.Infrastracture.EfCore
{
    public class ShopContext:DbContext
    {
        public ShopContext(DbContextOptions<ShopContext> options):base(options)
        {

        }

        public DbSet<ProductCategory> productCategories { get; set; }
        public DbSet<Product> Products { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly=typeof(ProductCategoryMapping).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
            
            base.OnModelCreating(modelBuilder);
        }
    }
}
