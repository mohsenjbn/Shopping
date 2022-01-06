﻿

using _01_framework.Application;
using ShopiManagement.Application.Contracts.ProductCategory;
using System.ComponentModel.DataAnnotations;

namespace ShopManagement.Application.Contracts.Product
{
    public class CreateProduct
    {
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Name { get;  set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Code { get;  set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public bool IsInStock { get;  set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public double UnitPrice { get;  set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string ShortDescribtion { get;  set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Describtion { get;  set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Picture { get;  set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string PictureAlt { get;  set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string PictureTitle { get;  set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string MetaDescribtion { get;  set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string keyWords { get;  set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Slug { get;  set; }

        [Range(1, 100000, ErrorMessage = ValidationMessages.IsRequired)]
        public long ProductCatagoryId { get;  set; }

        public List<ProductCategoryViewModel> Categories { get; set; }

    }


}
