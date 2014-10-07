using System.ComponentModel;
using MT.Utility.Localization.Services;

namespace MT.Utility.Localization.Attributes
{
    public class LocalizedDisplayNameAttribute : DisplayNameAttribute
    {
        private string _displayNameKey { get; set; }

        public LocalizedDisplayNameAttribute(string displayNameKey)
            : base(displayNameKey)
        {
            this._displayNameKey = displayNameKey;
        }

        public override string DisplayName
        {
            get
            {
                return LocalizationResourceServiceSingleton.Current.GetValue(_displayNameKey);
            }
        }
    }
}
