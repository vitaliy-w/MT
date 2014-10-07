namespace MT.Utility.Localization.Services
{
    public interface IKeyValueEntity
    {
        string ResourceKey { get; }
        string ResourceCultureCode { get; }
        string LocalizedResource { get; }
    }

    public class LocalizationReource : IKeyValueEntity
    {
        public string ResourceKey { get; set; }
        public string ResourceCultureCode { get; set; }
        public string LocalizedResource { get; set; }
    }
}