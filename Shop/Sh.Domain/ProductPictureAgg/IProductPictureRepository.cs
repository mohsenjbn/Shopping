using _01_framework.Domain;
using ShopManagement.Application.Contracts.ProductPicture;

namespace ShopManagement.Domain.ProductPictureAgg
{
    public interface IProductPictureRepository:IRepository<long,ProductPicture>
    {
        List<ProductPictureViewModel> GetAll(SearchProductPicture search);
        EditProductPicture GetDetals(long id);
    }
}
