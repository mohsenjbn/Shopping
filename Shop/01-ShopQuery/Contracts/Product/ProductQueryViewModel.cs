namespace _01_ShopQuery.Contracts.Product
{
    public class ProductQueryViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Picture { get; set; }
        public string PictureAlt { get; set; }
        public string PictureTitle { get; set; }
        public string UnitPrice { get; set; }
        public string PriceWithDiscoint { get; set; }
        public int DiscountRate { get; set; }
        public string Slug { get; set; }
        public bool Discount { get; set; }
        public string Category { get; set; }
        public string EndDateDiscount { get; set; }
    }
}
