using System.ComponentModel;
using MT.DomainLogic.Localization;

namespace MT.DomainLogic.Attributes
{
    public class LocalizedDisplayName : DisplayNameAttribute
    {
        private string _displayNameKey { get; set; }
        public ILocalizationResourceService LocalizationResourceService;

        public LocalizedDisplayName(string displayNameKey)
            : base(displayNameKey)
        {
            this._displayNameKey = displayNameKey;
        }

        public override string DisplayName
        {
            get
            {
                return LocalizationResourceService.GetValue(_displayNameKey);
            }
        }
    }

}
