using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.ComponentModel.DataAnnotations;
using asp_net_mvc_localization.Utils;
using System.Globalization;
using System.Threading;
using asp_net_mvc_localization.Resources;
using ModelMetadataExtensions;
using Resources;

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

            
            //Provide ValidationAttributes localization with client-side validation
            DataAnnotationsModelValidatorProvider.RegisterAdapter(typeof(RequiredAttribute), typeof(MyRequiredAttributeAdapter));
            DataAnnotationsModelValidatorProvider.RegisterAdapter(typeof(RangeAttribute), typeof(MyRangeAttributeAdapter));
            DataAnnotationsModelValidatorProvider.RegisterAdapter(typeof(MinLengthAttribute), typeof(MyMinLengthAttributeAdapter));
            DataAnnotationsModelValidatorProvider.RegisterAdapter(typeof(MaxLengthAttribute), typeof(MyMaxLengthAttributeAdapter));
            DataAnnotationsModelValidatorProvider.RegisterAdapter(typeof(RegularExpressionAttribute), typeof(MyRegularExpressionAttributeAdapter));
            DataAnnotationsModelValidatorProvider.RegisterAdapter(typeof(MyEmailAddressAttribute), typeof(MyEmailAddressAttribute)); 
            

            //Using universal Adapter, without client-side validation, because EmailAddressAttributeAdapter is not exist
            //DataAnnotationsModelValidatorProvider.RegisterAdapter(typeof(MyEmailAddressAttribute), typeof(ValidationAttributeAdapter));
            
            /*
            //Provide ValidationAttributes localization without client-side validation
            DataAnnotationsModelValidatorProvider.RegisterAdapter(typeof(RequiredAttribute), typeof(AttributeAdapters2.MySecRequiredAttributeAdapter));
            DataAnnotationsModelValidatorProvider.RegisterAdapter(typeof(RangeAttribute), typeof(AttributeAdapters2.MySecRangeAttributeAdapter));
            DataAnnotationsModelValidatorProvider.RegisterAdapter(typeof(MinLengthAttribute), typeof(AttributeAdapters2.MySecMinLengthAttributeAdapter));
            DataAnnotationsModelValidatorProvider.RegisterAdapter(typeof(MaxLengthAttribute), typeof(AttributeAdapters2.MySecMaxLengthAttributeAdapter));
            DataAnnotationsModelValidatorProvider.RegisterAdapter(typeof(RegularExpressionAttribute), typeof(AttributeAdapters2.MySecRegularExpressionAttributeAdapter)); 
            */

            //Provide DisplayAttribute localization
            ModelMetadataProviders.Current = new ConventionalModelMetadataProvider(false, typeof (AttributeResources));
            
            ClientDataTypeModelValidatorProvider.ResourceClassKey = "AttributeResources";
            DefaultModelBinder.ResourceClassKey = "AttributeResources";
        }

        protected void Application_AcquireRequestState(object sender, EventArgs e)
        {
            var langCookie = HttpContext.Current.Request.Cookies["lang"];
            if (langCookie == null)
            {

                //Sets default culture to english invariant
                string langName = "en-US";

                //Try to get values from Accept lang HTTP header
                if (HttpContext.Current.Request.UserLanguages != null && HttpContext.Current.Request.UserLanguages.Length != 0)
                {
                    //Gets accepted list 
                    langName = HttpContext.Current.Request.UserLanguages[0].Substring(0, 2);
                }

                langCookie = new HttpCookie("lang", langName)
                {
                    HttpOnly = true
                };


                HttpContext.Current.Response.AppendCookie(langCookie);

            }

            
            var ci = new CultureInfo(langCookie.Value);
            //Checking first if there is no value in session 
            //and set default language 
            //this can happen for first user's request

            //Finally setting culture for each request
            Thread.CurrentThread.CurrentUICulture = ci;
            Thread.CurrentThread.CurrentCulture = ci;

            //The line below creates issue when using default culture values for other
            //cultures for ex: NumericSepratore.
            //Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(ci.Name);
        }
    }
}
