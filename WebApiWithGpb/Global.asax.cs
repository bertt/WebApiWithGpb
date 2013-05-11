using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using WebApiContrib.Formatting;

namespace WebApiWithGpb
{
    public class Global : System.Web.HttpApplication
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.Ignore("{resource}.axd/{*pathInfo}");

            // home route
            routes.MapHttpRoute(
                "Home", // Route name 
                "api", // URL with parameters 
                new { controller = "Home" } // Parameter defaults 
            );

            routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            //routes.MapHttpRoute("bag", "api/bag/{*path}");
        }




        protected void Application_Start(object sender, EventArgs e)
        {
            RegisterRoutes(RouteTable.Routes);
            GlobalConfiguration.Configuration.Formatters.Add(new ProtoBufFormatter());
        }
    }
}