using System;
using System.Net.Http.Formatting;
using System.Web.Http;
using System.Web.Routing;
using WebApiContrib.Formatting;

namespace WebApiWithGpb
{
    public class Global : System.Web.HttpApplication
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.Ignore("{resource}.axd/{*pathInfo}");
            var config = GlobalConfiguration.Configuration;
            config.Routes.MapHttpRoute(
                name: "ControllerWithExt",
                routeTemplate: "api/{controller}.{ext}");
            config.Routes.MapHttpRoute(
                name: "IdWithExt",
                routeTemplate: "api/{controller}/{id}.{ext}");
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

        }

        protected void Application_Start(object sender, EventArgs e)
        {
            GlobalConfiguration.Configuration.Formatters.JsonFormatter.MediaTypeMappings.Add(new UriPathExtensionMapping("json", "application/json"));

            RegisterRoutes(RouteTable.Routes);

            GlobalConfiguration.Configuration.Formatters.Add(new ProtoBufFormatter());
            GlobalConfiguration.Configuration.Formatters.Add(new CsvFormatter());

            // test for uripathextensionmapping

        }
    }
}