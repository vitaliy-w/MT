using System.Collections.Generic;
using System.Linq;
using MT.DataAccess.EntityFramework;
using MT.ModelEntities.Entities;
using MT.Utility;

namespace MT.DomainLogic.Localization
{
    public class LocalizationResourceService : ILocalizationResourceService
    {
        private readonly IUnitOfWork _unitOfWork;

        public LocalizationResourceService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Create(LocalizationResource libraryResource)
        {
            _unitOfWork.Add(libraryResource);
        }

        /// <summary>
        /// Adds new entries to data base if they are not already exist and returns quantity succesfully added items.
        /// </summary>
        public int Create(IEnumerable<LocalizationResource> resources)
        {
            int itemsAddedToDb = 0;
            foreach (var resource in resources)
            {

                if (!IsPresent(resource))
                {
                    _unitOfWork.Add(resource);
                    itemsAddedToDb++;
                }
            }

            return itemsAddedToDb;
        }

        /// <summary>
        /// Checks if item already present in database.
        /// </summary>

        public bool IsPresent(LocalizationResource resource)
        {
            var isPresent = _unitOfWork.Get<LocalizationResource>().Any(entry => ((entry.ResourceKey == resource.ResourceKey)
                                                                             &&
                                                                             (entry.ResourceCultureCode == resource.ResourceCultureCode)));
            return isPresent;
        }

    }
}