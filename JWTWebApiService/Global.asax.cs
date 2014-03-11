using System;
using System.Web.Http;
using System.Web.Routing;
using JWTWebApiService.Utilities;
using WebApiContrib.IoC.Ninject;

namespace JWTWebApiService
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            RouteTable.Routes.MapHttpRoute("JWTWebApiService", "{controller}/{id}", new { id = RouteParameter.Optional });

            GlobalConfiguration.Configuration.DependencyResolver = new NinjectResolver(IocContainer.Initialize());
            GlobalConfiguration.Configuration.Formatters.XmlFormatter.SupportedMediaTypes.Clear();
        }
    }
}