using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.Mvc;
using MT.DomainLogic.Localization;
using MT.Utility.Localization.AttributeAdapters;
using MT.Utility.Localization.Attributes;
using MT.Web.App_Start;
using MT.Web.Infrastructure;

namespace MT.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);


            RegisterAttributeAdapters();
            SetupIocContainer();
        }

        private static void RegisterAttributeAdapters()
        {
            DataAnnotationsModelValidatorProvider.RegisterAdapter(typeof(LocalizedCompareAttribute), typeof(LocalizedCompareAttributeAdapter));
            DataAnnotationsModelValidatorProvider.RegisterAdapter(typeof(LocalizedEmailAttribute), typeof(LocalizedEmailAttributeAdapter));
            DataAnnotationsModelValidatorProvider.RegisterAdapter(typeof(LocalizedRangeAttribute), typeof(LocalizedRangeAttributeAdapter));
            DataAnnotationsModelValidatorProvider.RegisterAdapter(typeof(LocalizedRegularExpressionAttribute), typeof(LocalizedRegularExpressionAttributeAdapter));
            DataAnnotationsModelValidatorProvider.RegisterAdapter(typeof(LocalizedRequiredAttribute), typeof(LocalizedRequiredAttributeAdapter));
        }

        private static void SetupIocContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterModule<AutofacWebTypesModule>();
            builder.RegisterModule<MtAutofacModule>();


            IContainer container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
   
}
