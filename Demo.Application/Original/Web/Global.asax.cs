using System.Diagnostics;
using System.Reflection;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
//using Microsoft.ApplicationInsights.Extensibility;
using Monitoring.Demo;

namespace Loftysoft.Demo.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        // ReSharper disable once MemberCanBePrivate.Global
        public static string Version { get; private set; }

        protected void Application_Start()
        {
            var executingAssembly = Assembly.GetExecutingAssembly();
            var fileVersionInfo = FileVersionInfo.GetVersionInfo(executingAssembly.Location);
            Version = fileVersionInfo.FileVersion;

            //TelemetryConfiguration.Active.TelemetryInitializers.Add(new VersionTelemetryInitializer(Version));

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}