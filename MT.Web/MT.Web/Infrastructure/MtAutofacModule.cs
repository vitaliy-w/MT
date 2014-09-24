using System.Configuration;
using Autofac;
using Autofac.Integration.Mvc;
using MT.DataAccess.EntityFramework;

namespace MT.Web.Infrastructure
{
    public class MtAutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            RegisterServices(builder);
        }


        private static void RegisterServices(ContainerBuilder builder)
        {
            string dbConnectionString = ConfigurationManager.ConnectionStrings["MentorConnectionString"].ConnectionString;

            builder.RegisterType<DataAccessFactory<MentorDataContext>>().As<IDataAccessFactory>().WithParameter("connectionString", dbConnectionString).SingleInstance();
            builder.Register(c => c.Resolve<IDataAccessFactory>().CreateUnitOfWork()).As<IUnitOfWork>();
        }
    }
}