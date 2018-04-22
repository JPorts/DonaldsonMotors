using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace DonaldsonMotorsThree
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Create settings for formatting JSON //
            var settings = config.Formatters.JsonFormatter.SerializerSettings;
            // Set Camel Case resolver for JSON Objects from APIs //
            settings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            // Indent formatting // 
            settings.Formatting = Formatting.Indented;

            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
