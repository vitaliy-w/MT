using System.Linq;
using MT.DataAccess.EntityFramework;
using MT.ModelEntities.Entities;

namespace MT.DomainLogic
{
    public class ProjectRequestService : IProjectRequestService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProjectRequestService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void SaveOrUpdateRequest(ProjectRequest request)
        {
            if (request.Id == 0)
            {
                _unitOfWork.Add(request);
            }
            else
            {
                var existingRequest = _unitOfWork.Get<ProjectRequest>().FirstOrDefault(r => r.Id == request.Id);
                if (existingRequest != null)
                {
                    existingRequest.Name = request.Name;
                    existingRequest.Description = request.Description;
                    existingRequest.RequestPostingVisibility = request.RequestPostingVisibility;
                    existingRequest.PreferredCandidateLocation = request.PreferredCandidateLocation;
                    existingRequest.PostPeriod = request.PostPeriod;
                    existingRequest.StartDate = request.StartDate;
                }
                else
                {
                    _unitOfWork.Add(request);
                }
            }
        }
    }
}
