using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace Log4Javascript.Web
{
    public class Register
    {
        public static void WebApi(HttpConfiguration config, string baseRoute)
        {

            config.Routes.MapHttpRoute(
                name: "Logging",
                routeTemplate: baseRoute + "/{action}",
                defaults: new { controller = "Logs", action = "Write" }
            );
        }
    }
}
