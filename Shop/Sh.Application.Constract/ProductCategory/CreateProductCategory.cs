using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopiManagement.Application.Contracts.ProductCategory
{
    public class CreateProductCategory
    {
        public string Name { get;  set; }
        public string Picture { get;  set; }
        public string Describtion { get;  set; }
        public string PictureAlt { get;  set; }
        public string PictureTitle { get;  set; }
        public string KeyWords { get;  set; }
        public string MetaDescribtion { get;  set; }
        public string Slug { get;  set; }
    }
}
