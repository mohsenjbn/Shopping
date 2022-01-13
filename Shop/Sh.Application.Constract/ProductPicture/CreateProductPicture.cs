namespace ShopManagement.Application.Contracts.ProductPicture
{
    public class CreateProductPicture
    {
        public string Picture { get;  set; }
        public string PictureTitle { get;  set; }
        public string PictureAlt { get;  set; }
        public bool IsDeleted { get;  set; }
        public long ProductId { get;  set; }
    }
}
