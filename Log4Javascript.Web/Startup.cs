using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Newtonsoft.Json;

namespace Log4Javascript.Web
{
    public class Startup
    {
        public static void WebApi(HttpConfiguration config, string baseRoute)
        {
            var json = config.Formatters.JsonFormatter;
            json.SerializerSettings.PreserveReferencesHandling = PreserveReferencesHandling.None;
            config.Formatters.Remove(config.Formatters.XmlFormatter);
            config.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            var enumConverter = new Newtonsoft.Json.Converters.StringEnumConverter();
            json.SerializerSettings.Converters.Add(enumConverter);

            config.Routes.MapHttpRoute(
                name: "Logging",
                routeTemplate: baseRoute + "/{action}",
                defaults: new { controller = "Logs", action = "Write" }
            );
        }
    }
}
