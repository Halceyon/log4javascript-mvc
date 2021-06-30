# log4javascript-mvc

log4javascript-mvc is a MVC Web Api implementation of the log4javascript framework.  It uses Entity Framework to persist the client logs to a database.  Currently it uses the "DefaultConnection" connection string from web.config to get the database information.

To get started you need to install the Nuget package: 

```console
Install-Package log4javascript-mvc
```

Once the package has been installed, you need to register the Web Api route, by adding the following to your *App_Start\WebApiConfig.cs*:

```javascript
Log4Javascript.Web.Register.WebApi(config, "JsLogging");
```

The following formatters need to be registered in your *App_Start\WebApiConfig.cs*:

```javascript
var json = config.Formatters.JsonFormatter;
var enumConverter = new Newtonsoft.Json.Converters.StringEnumConverter();
json.SerializerSettings.Converters.Add(enumConverter);
```

Where "JsLogging" is the base route you want to provide, so the route for logging will be:  ~/JsLogging/Write

Next you need to set the ajax appender for log4javascript

```javascript
var ajaxAppender = new log4javascript.AjaxAppender('@Url.Content("~/JsLogging/Write")');
ajaxAppender.setLayout(new log4javascript.JsonLayout());
ajaxAppender.addHeader("Content-Type", "application/json; charset=utf-8");
```

All done, Entity Framework will create the table ClientLogs in the database connection specified by "DefaultConnection" and your client side javascript logs will be uploaded via Web Api.

Special thanks to Markus Wagner for this [blog post](http://ritzlgrmft.blogspot.com/2013/11/log4javascript-and-aspnet-web-api.html") which helped a lot and of course for the awesome javascript logging framework that is [log4javascript](http://log4javascript.org).
