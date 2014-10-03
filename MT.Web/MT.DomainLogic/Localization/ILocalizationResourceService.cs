using MT.ModelEntities.Entities;

namespace MT.DomainLogic.Localization
{
    public interface ILocalizationResourceService
    {
        string GetValue(string resourceKey, string resourceClass = "");

        void Create(LocalizationResource libraryResource);
    }
}