using MT.DataAccess.EntityFramework;
using MT.ModelEntities.Entities;




namespace MT.DomainLogic
{
    public static class ResourceLogic
    {
        public static void SaveResource(IUnitOfWork db, Resource resource)
        {
            if (db == null || resource == null) return;
            db.Add(resource);
            db.Commit();
        }
    }
}
