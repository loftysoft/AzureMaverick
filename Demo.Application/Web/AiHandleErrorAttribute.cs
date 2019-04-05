using System;
using System.Web.Mvc;
//using Microsoft.ApplicationInsights;

namespace Loftysoft.Demo.Web
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class AiHandleErrorAttribute : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            if (filterContext?.HttpContext != null && filterContext.Exception != null)
            {
                //var telemetryClient = new TelemetryClient();
                //telemetryClient.TrackException(filterContext.Exception);
            }
            base.OnException(filterContext);
        }
    }
}