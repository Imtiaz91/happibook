using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Dispatcher;
using System.Web.Http.ExceptionHandling;
using Happibook.API.Infrastructure;
using Happibook.API.Provider;
using Happibook.Core;
using Microsoft.Practices.Unity;
using Newtonsoft.Json.Serialization;

namespace Happibook.API
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes(new CentralizedPrefixProvider("api"));

            var container = IoC.Container;
            container.RegisterInstance<IHttpControllerActivator>(new UnityHttpControllerActivator(container));
            config.Services.Replace(typeof(IHttpControllerActivator), new UnityHttpControllerActivator(container));

            // var appXmlType = config.Formatters.XmlFormatter.SupportedMediaTypes.FirstOrDefault(t => t.MediaType == "application/xml");
            // config.Formatters.XmlFormatter.SupportedMediaTypes.Remove(appXmlType);
            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));
            config.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            config.Services.Replace(typeof(IExceptionHandler), new GlobalErrorHandling());
            GlobalConfiguration.Configuration.DependencyResolver = config.DependencyResolver;

            EnableCorsAttribute cors = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors(cors);

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional });

            config.Routes.MapHttpRoute(
                            name: "ActionApi",
                            routeTemplate: "api/{controller}/{action}/{id}",
                            defaults: new { id = RouteParameter.Optional });

            config.Routes.MapHttpRoute(
                name: "Angular",
                routeTemplate: "{*anything}",
                defaults: new { controller = "Auth", action = "Angular" });
        }
    }
}