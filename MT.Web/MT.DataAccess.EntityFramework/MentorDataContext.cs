using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using MT.ModelEntities.Entities;

namespace MT.DataAccess.EntityFramework
{
    public class MentorDataContext : DbContext
    {
        public MentorDataContext()
            : base("MentorConnectionString")
        {
            Database.SetInitializer<MentorDataContext>(new DropCreateDatabaseIfModelChanges<MentorDataContext>());
        }

        public MentorDataContext(string connectionString)
            : base(connectionString)
        {
            Database.SetInitializer<MentorDataContext>(new DropCreateDatabaseIfModelChanges<MentorDataContext>());
            // Sets the default command timeout 1.5 minutes.
            ((IObjectContextAdapter)this).ObjectContext.CommandTimeout = 90;
        }

        public DbSet<User> Users { get; set; }

        public DbSet<ExternalUser> ExternalUsers { get; set; }

        public DbSet<ProjectRequest> PostYourRequests { get; set; }

        public DbSet<LibraryResource> Resources { get; set; }

        public DbSet<LocalizationResource> LocalisationResources { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
           // base.OnModelCreating(modelBuilder);
        }
    }
}
