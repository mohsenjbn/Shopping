﻿

namespace ShopManagement.Application.Contracts.Product
{
    public class ProductViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string  CreationDate { get; set; }
        public string CategoryName { get; set; }
        public string Picture { get; set; }
        public bool IsInStock { get; set; }
        public string UnitPrice { get; set; }
        public string code { get; set; }


    }


}
