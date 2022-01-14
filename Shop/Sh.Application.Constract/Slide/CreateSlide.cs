

using _01_framework.Application;
using System.ComponentModel.DataAnnotations;

namespace ShopManagement.Application.Contracts.Slide
{
    public class CreateSlide
    {
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Picture { get;  set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string PictureAlt { get;  set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string PictureTitle { get;  set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Heading { get;  set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Title { get;  set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Btntext { get;  set; }
      

    }
}
