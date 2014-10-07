using System;
using System.Linq;

namespace MT.Utility.Localization.Services
{
    public class LocalizationResourceServiceSingleton
    {
        private static readonly object LockObject = new object();
        
        private static ILocalizationResourceCache _current;

        public static ILocalizationResourceCache Current
        {
            get
            {
                if (_current == null)
                {
                    lock (LockObject)
                    {
                        if (_current == null)
                        {
                            Reset();
                        }
                    }
                }
                return _current;
            }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("value");
                _current = value;
            }
        }

        public static void Reset()
        {
            _current = new LocalizationResourceCache();
        }
    }
}
