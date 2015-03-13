using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Routing;
using MYDZ.WebUI.App_Start;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;

namespace MYDZ.WebUI
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start() {
            AreaRegistration.RegisterAllAreas();
            
            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
