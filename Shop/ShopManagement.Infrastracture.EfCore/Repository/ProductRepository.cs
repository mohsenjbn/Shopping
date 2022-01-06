﻿using _01_framework.Infrastracture;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Application.Contracts.Product;
using ShopManagement.Domain.ProductAgg;

namespace ShopManagement.Infrastracture.EfCore.Repository
{
    public class ProductRepository : RepositoryBase<long, Product>, IProductRepository
    {
        private readonly ShopContext _context;
        public ProductRepository(ShopContext context) : base(context)
        {
            _context = context;
        }

        public List<ProductViewModel> GetAll(SearchModelProduct search)
        {
            var query = _context.Products.Include(p => p.ProductCategory).Select(p => new ProductViewModel()
            {
                Name=p.Name,
                CategoryName=p.ProductCategory.Name,
                code=p.Code,
                CreationDate=p.CreationDate.ToString(), 
                Id=p.Id,
                IsInStock=p.IsInStock,
                Picture=p.Picture,
                UnitPrice=p.UnitPrice.ToString(),

            }).ToList();

            if (!string.IsNullOrWhiteSpace(search.Name))
                query.Where(p => p.Name.Contains(search.Name)).ToList();

            if(!string.IsNullOrWhiteSpace(search.Code))
                query.Where(p => p.code.Contains(search.Code)).ToList();

            if(search.CategoryId>0)
                query.Where(p=>p.Id==search.CategoryId).ToList();

            return query.OrderByDescending(p => p.Id).ToList();


        }

        public EditProduct GetDetail(long id)
        {
            return _context.Products.Select(p => new EditProduct()
            {
                Code = p.Code,
                Id = p.Id,
                Describtion = p.Describtion,
                IsInStock = p.IsInStock,
                keyWords = p.keyWords,
                MetaDescribtion = p.MetaDescribtion,
                Name = p.Name,
                Picture = p.Picture,
                PictureAlt = p.PictureAlt,
                PictureTitle = p.PictureTitle,
                ProductCatagoryId = p.ProductCatagoryId,
                ShortDescribtion = p.ShortDescribtion,
                Slug = p.Slug,
                UnitPrice = p.UnitPrice,
            }).FirstOrDefault(p => p.Id == id);
        }
    }
}
