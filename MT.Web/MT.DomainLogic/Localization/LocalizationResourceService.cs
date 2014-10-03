using MT.DataAccess.EntityFramework;
using MT.ModelEntities.Entities;

namespace MT.DomainLogic.Localization
{
    public class LocalizationResourceService : ILocalizationResourceService
    {
        private readonly IUnitOfWork _unitOfWork;

        public LocalizationResourceService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public string GetValue(string resourceKey, string resourceClass)
        {
            return "Missing Key";
        }

        public void Create(LocalizationResource libraryResource)
        {
            _unitOfWork.Add(libraryResource);
        }
    }
}
