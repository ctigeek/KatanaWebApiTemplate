using System;
using System.Web.Http;
using log4net;
using log4net.Core;
using Owin;

namespace KatanaWebApiTemplate
{
    internal class Startup
    {
        private static ILog log = LogManager.GetLogger(typeof(Startup));
        private static bool debug;

        static Startup()
        {
            debug = ((log4net.Repository.Hierarchy.Hierarchy)LogManager.GetRepository()).Root.Level.Value <= Level.Debug.Value;
        }

        public void Configuration(IAppBuilder appBuilder)
        {
            if (debug)
            {
                appBuilder.Use(async (env, next) =>
                {
                    log.Debug("Http method: " + env.Request.Method + ", path: " + env.Request.Path);
                    await next();
                    log.Debug("Response code: " + env.Response.StatusCode);
                });
            }
            RunWebApiConfiguration(appBuilder);
        }

        private void RunWebApiConfiguration(IAppBuilder appBuilder)
        {
            var httpConfiguration = new HttpConfiguration();
            httpConfiguration.Routes.MapHttpRoute(
                name: "WebApi"
                , routeTemplate: "{controller}/{id}"
                , defaults: new { id = RouteParameter.Optional }
                );
            appBuilder.UseWebApi(httpConfiguration);
        }
    }
}
