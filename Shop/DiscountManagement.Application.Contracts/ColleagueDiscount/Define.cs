﻿using _01_framework.Application;
using ShopManagement.Application.Contracts.Product;
using System.ComponentModel.DataAnnotations;

namespace DiscountManagement.Application.Contracts.ColleagueDiscount
{
    public class Define
    {
        [Range(1, 100000, ErrorMessage = ValidationMessages.IsRequired)]
        public long ProductId { get; set; }

        [Range(1, 99, ErrorMessage = ValidationMessages.DiscountRange)]
        public int DiscountRate { get; set; }
        public List<ProductViewModel> Products { get; set; }
    }
}
