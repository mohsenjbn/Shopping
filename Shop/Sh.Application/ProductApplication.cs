
using _0_Framework.Application;
using _01_framework.Application;
using ShopManagement.Application.Contracts.Product;
using ShopManagement.Domain.ProductAgg;

namespace ShopManagement.Application
{
    public class ProductApplication:IProductApplication
    {
        private readonly IProductRepository _productRepository;

        public ProductApplication(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public OperationResult Create(CreateProduct command)
        {
            var operation=new OperationResult();
            if (_productRepository.IsExist(x => x.Name == command.Name))
                return operation.Failed(ResultMessage.IsDoblicated);

            var Slug=command.Slug.Slugify();
            var product = new Product(command.Name, command.Code,
                command.UnitPrice, command.ShortDescribtion, command.Describtion,
                command.Picture, command.PictureAlt, command.PictureTitle,
                command.MetaDescribtion, command.keyWords, Slug, command.ProductCatagoryId);

            _productRepository.Create(product);
            _productRepository.Savechanges();
            return operation.IsSucssed();


        }

        public OperationResult Edit(EditProduct command)
        {
            var operation = new OperationResult();
            var product = _productRepository.GetBy(command.Id);

            if(product == null)
                return operation.Failed(ResultMessage.IsNotExistRecord);

            if (_productRepository.IsExist(p => p.Name == command.Name && p.Id != command.Id))
                return operation.Failed(ResultMessage.IsDoblicated);

            var slug = command.Slug.Slugify();
            product.Edit(command.Name, command.Code,
                command.UnitPrice, command.ShortDescribtion, command.Describtion,
                command.Picture, command.PictureAlt, command.PictureTitle,
                command.MetaDescribtion, command.keyWords, slug, command.ProductCatagoryId);
            _productRepository.Savechanges();
            return operation.IsSucssed();
        }

        public List<ProductViewModel> GetAll(SearchModelProduct search)
        {
            return _productRepository.GetAll(search);
        }

        public EditProduct GetDetails(long id)
        {
          return _productRepository.GetDetail(id);
        }

        public OperationResult IsInStock(long id)
        {
            var operation = new OperationResult();
            var product = _productRepository.GetBy(id);
            if (product == null)
                return operation.Failed(ResultMessage.IsNotExistRecord);

            product.IsStock();
            _productRepository.Savechanges();
            return operation.IsSucssed();
        }

        public OperationResult NotIsStock(long id)
        {
            var operation = new OperationResult();
            var product = _productRepository.GetBy(id);
            if (product == null)
                return operation.Failed(ResultMessage.IsNotExistRecord);

            product.NotInStock();
            _productRepository.Savechanges();
            return operation.IsSucssed();
        }

       

    }
}
