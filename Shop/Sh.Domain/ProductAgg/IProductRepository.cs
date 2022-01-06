﻿
using _01_framework.Domain;
using ShopManagement.Application.Contracts.Product;

namespace ShopManagement.Domain.ProductAgg
{
    public interface IProductRepository:IRepository<long,Product>
    {

        List<ProductViewModel> GetAll(SearchModelProduct search);
        EditProduct GetDetail(long id);
    }
}