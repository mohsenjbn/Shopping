﻿namespace ShopiManagement.Application.Contracts.ProductCategory
{
    public class ProDuctCategoryViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public string picture { get; set; }

        public long ProductCount { get; set; }

        public string CreationDate { get; set; }
    }
}
