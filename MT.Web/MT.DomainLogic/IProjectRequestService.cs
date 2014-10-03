using MT.ModelEntities.Entities;

namespace MT.DomainLogic
{
    /// <summary>
    /// Describes the functionality to work with request on a project or something else.
    /// </summary>
    public interface IProjectRequestService
    {
        /// <summary>
        /// Saves a new request or an update existing one.
        /// </summary>
        void SaveOrUpdateRequest(ProjectRequest request);
    }
}