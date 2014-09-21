namespace MT.Web.Infrastructure
{
    /// <summary>
    /// Represents the path which should be added to correct work with angular model. 
    /// </summary>
    public class NgModelPathOptions
    {
        public string Prefix { get; set; }
        public int SkipParts { get; set; }
    }
}