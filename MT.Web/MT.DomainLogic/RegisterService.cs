using MT.DataAccess.EntityFramework;
using MT.ModelEntities.Entities;

namespace MT.DomainLogic
{
    public class RegisterService
    {

        public void SaveUser(IUnitOfWork db, User user)
        {
            if (db == null || user == null)    
                return;
            
            db.Add(user);
            db.Commit();
        }
    }
}
