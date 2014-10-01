using MT.DataAccess.EntityFramework;
using MT.ModelEntities.Entities;


namespace MT.DomainLogic
{
    public class ResourceService
    {
        /// <summary>
        /// Service method. Save resource item to db
        /// </summary>
        /// <param name="db">Instance of IUnitOfWork type</param>
        /// <param name="resource">Data represent that need write to db</param>
        public void SaveResource(IUnitOfWork db, Resource resource)
        {
            if (db == null || resource == null) return;
            db.Add(resource);
            db.Commit();
        }
    }
}
