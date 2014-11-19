using System.Configuration;
using Autofac;
using MT.DataAccess.EntityFramework;
using MT.DomainLogic;
using MT.DomainLogic.Localization;
using MT.DomainLogic.PersonalCabinet;

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
            builder.Register(c => c.Resolve<IDataAccessFactory>().CreateUnitOfWork()).As<IUnitOfWork>().SingleInstance();

            builder.RegisterType<ProjectRequestService>().As<IProjectRequestService>();
            builder.RegisterType<LibraryResourceService>().As<ILibraryResourceService>();
            builder.RegisterType<UserService>().As<IUserService>();
            builder.RegisterType<LocalizationResourceService>().As<ILocalizationResourceService>();
            builder.RegisterType<TechnologyService>().As<ITechnologyService>();
            builder.RegisterType<UserLoginService>().As<IUserLoginService>();
            builder.RegisterType<AccountService>().As<IAccountService>();
            builder.RegisterType<UserEducationService>().As<IUserEducationService>();

        }
    }
}