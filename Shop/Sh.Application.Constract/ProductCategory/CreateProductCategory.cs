
using _01_framework.Application;
using System.ComponentModel.DataAnnotations;

namespace ShopiManagement.Application.Contracts.ProductCategory
{
    public class CreateProductCategory
    {
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Name { get;  set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Picture { get;  set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Describtion { get;  set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string PictureAlt { get;  set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string PictureTitle { get;  set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string KeyWords { get;  set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string MetaDescribtion { get;  set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Slug { get;  set; }
    }
}
