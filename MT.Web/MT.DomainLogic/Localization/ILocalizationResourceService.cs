using System.Collections.Generic;
using MT.ModelEntities.Entities;

namespace MT.DomainLogic.Localization
{
    public interface ILocalizationResourceService
    {
        void Create(LocalizationResource libraryResource);

        int Create(IEnumerable<LocalizationResource> resources);

    }
}