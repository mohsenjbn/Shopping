using _01_framework.Application;
using ShopManagement.Application.Contracts.ProductPicture;
using ShopManagement.Domain.ProductPictureAgg;

namespace ShopManagement.Application
{
    public class ProductPictureApplication : IProductPictureApplication
    {
        private readonly IProductPictureRepository _productPictureRepository;

        public ProductPictureApplication(IProductPictureRepository productPictureRepository)
        {
            _productPictureRepository = productPictureRepository;
        }

        public OperationResult Create(CreateProductPicture command)
        {
            var Operation=new OperationResult();
            if (_productPictureRepository.IsExist(p => p.Picture == command.Picture))
                return Operation.Failed(ResultMessage.IsDoblicated);

            var ProductPicture=new ProductPicture(command.Picture,command.
                PictureTitle,command.PictureAlt,command.ProductId);

            _productPictureRepository.Create(ProductPicture);
            _productPictureRepository.Savechanges();
            return Operation.IsSucssed();
        }

        public OperationResult Edit(EditProductPicture command)
        {
            var Operation= new OperationResult();

            var ProductPicture = _productPictureRepository.GetBy(command.Id);

            if (ProductPicture == null)
                return Operation.Failed(ResultMessage.IsNotExistRecord);

            if (_productPictureRepository.IsExist(p => p.Picture == command.Picture && p.ProductId == command.ProductId))
                return Operation.Failed(ResultMessage.IsDoblicated);

            ProductPicture.Edit(command.Picture, command.
                PictureTitle, command.PictureAlt, command.ProductId);
            _productPictureRepository.Savechanges();

            return Operation.IsSucssed();
        }

        public List<ProductPictureViewModel> GetAll(SearchProductPicture search)
        {
            return _productPictureRepository.GetAll(search);
        }

        public EditProductPicture GetDetails(long id)
        {
            return _productPictureRepository.GetDetals(id);
        }

        public OperationResult IsRemove(long id)
        {
            var Operation = new OperationResult();

            var ProductPicture = _productPictureRepository.GetBy(id);

            if (ProductPicture == null)
                return Operation.Failed(ResultMessage.IsNotExistRecord);



            ProductPicture.Remove();
            _productPictureRepository.Savechanges();

            return Operation.IsSucssed();
        }

        public OperationResult Restore(long id)
        {
            var Operation = new OperationResult();

            var ProductPicture = _productPictureRepository.GetBy(id);

            if (ProductPicture == null)
                return Operation.Failed(ResultMessage.IsNotExistRecord);



            ProductPicture.Restore();
            _productPictureRepository.Savechanges();

            return Operation.IsSucssed();
        }
    }
}
