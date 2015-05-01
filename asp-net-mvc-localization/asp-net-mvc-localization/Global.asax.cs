using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace asp_net_mvc_localization
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //Doesn't work
            /*
            ModelMetadataProviders.Current = new ConventionalModelMetadataProvider(
                  requireConventionAttribute: false,
                  defaultResourceType: typeof(ValidationResources)
            );

            //ModelBinders.Binders.Add(typeof(decimal), new DecimalModelBinder());
            //ModelBinders.Binders.Add(typeof(double), new DoubleModelBinder());

            ClientDataTypeModelValidatorProvider.ResourceClassKey = "ValidationResources";
            DefaultModelBinder.ResourceClassKey = "ValidationResources";

            DataAnnotationsModelValidatorProvider.RegisterAdapter(
                typeof(RequiredAttribute), typeof(MyRequiredAttributeAdapter));

            DataAnnotationsModelValidatorProvider.RegisterAdapter(
                typeof(StringLengthAttribute), typeof(MyStringLengthAttributeAdapter));
             */
        }

        
    }
}
