using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using MT.ModelEntities.Entities;

namespace MT.DataAccess.EntityFramework
{
    public class MentorDataContext: DbContext
    {
        public MentorDataContext() : base("MentorConnectionString")
        {
            Database.SetInitializer<MentorDataContext>(new DropCreateDatabaseAlways<MentorDataContext>());
        }

        public MentorDataContext(string connectionString)
            : base(connectionString)
        {
            // Sets the default command timeout 1.5 minutes.
            ((IObjectContextAdapter)this).ObjectContext.CommandTimeout = 90;
        }

        public DbSet<User> Users { get; set; }

        public DbSet<MT.ModelEntities.Entities.LocalisationResource>  LocalisationResources { get; set; }
    }
}
