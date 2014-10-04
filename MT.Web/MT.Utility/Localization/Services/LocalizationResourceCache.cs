using System.Collections.Generic;
using System.Linq;

namespace MT.Utility.Localization.Services
{
    public class LocalizationResourceCache : ILocalizationResourceCache
    {
        private Dictionary<string, IList<IKeyValueEntity>> _cache;

        public LocalizationResourceCache()
        {
            _cache = new Dictionary<string, IList<IKeyValueEntity>>();
            var query = AdoReader.ReadResources();

            if (query != null)
            {
                var list = query.ToArray();
                foreach (var resource in list)
                {
                    if (_cache.ContainsKey(resource.ResourceKey))
                    {
                        _cache[resource.ResourceKey].Add(resource);
                    }
                    else
                    {
                        _cache.Add(resource.ResourceKey, new List<IKeyValueEntity>() { resource });
                    }
                }
            }

        }

        public string GetValue(string key)
        {
            var culture = CultureService.CurrentCulture();
            return _cache.ContainsKey(key) && _cache[key].Any(r => r.ResourceCultureCode == culture) ? 
                _cache[key].First(r => r.ResourceCultureCode == culture).LocalizedResource 
                : "Missing Key";
        }
    }
}