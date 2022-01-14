using _01_framework.Application;
using ShopManagement.Application.Contracts.Slide;
using ShopManagement.Domain.SlideAgg;

namespace ShopManagement.Application
{
    public class SlideApplication : ISlideApplication
    {
        private readonly ISlideRepository _sliseRepository;

        public SlideApplication(ISlideRepository sliseRepository)
        {
            _sliseRepository = sliseRepository;
        }

        public OperationResult CreateSlide(CreateSlide command)
        {
            var Operation = new OperationResult();
            if (command == null)
                return Operation.Failed(ResultMessage.IsDoblicated);
            var slide=new Slide(command.Picture,command.PictureAlt,command.PictureTitle,command.Heading,command.Title,command.Btntext);
            _sliseRepository.Create(slide);
            _sliseRepository.Savechanges();
            return Operation.IsSucssed();
        }

        public OperationResult EditSlide(EditSlide command)
        {
            var Operation = new OperationResult();
            var slide=_sliseRepository.GetBy(command.Id);
            if (slide == null)
                return Operation.Failed(ResultMessage.IsNotExistRecord);

            slide.Edit(command.Picture, command.PictureAlt, command.PictureTitle, command.Heading, command.Title, command.Btntext);
            _sliseRepository.Savechanges();

            return Operation.IsSucssed();

           
        }

        public List<SlideViewModel> GetAll()
        {
            return _sliseRepository.GetAll();
        }

        public EditSlide GetDetail(long id)
        {
            return _sliseRepository.GetDetail(id);
        }

        public OperationResult Remove(long id)
        {
            var Operation = new OperationResult();
            var slide = _sliseRepository.GetBy(id);
            if (slide == null)
                return Operation.Failed(ResultMessage.IsNotExistRecord);

            slide.Remove();
            _sliseRepository.Savechanges();

            return Operation.IsSucssed();

        }

        public OperationResult Restore(long id)
        {
            var Operation = new OperationResult();
            var slide = _sliseRepository.GetBy(id);
            if (slide == null)
                return Operation.Failed(ResultMessage.IsNotExistRecord);

            slide.Remove();
            _sliseRepository.Savechanges();

            return Operation.IsSucssed();
        }
    }
}
