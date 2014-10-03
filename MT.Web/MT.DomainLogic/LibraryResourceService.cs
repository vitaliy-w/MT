using MT.DataAccess.EntityFramework;
using MT.ModelEntities.Entities;

namespace MT.DomainLogic
{
    public class LibraryResourceService : ILibraryResourceService
    {
        private readonly IUnitOfWork _unitOfWork;

        public LibraryResourceService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Create(LibraryResource resource)
        {
            _unitOfWork.Add(resource);
        }
    }
}
