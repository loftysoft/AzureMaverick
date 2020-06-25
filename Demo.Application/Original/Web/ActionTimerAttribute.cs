using System;
using System.Diagnostics;
using System.Web.Mvc;

namespace Loftysoft.Demo.Web
{
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
	public class ActionTimerAttribute : ActionFilterAttribute
	{
		private const string ActionTimerPlaceholder = "_ActionTimer";
		public const string ViewDataKey = "_ElapsedTime";

		public ActionTimerAttribute()
		{
			Order = int.MaxValue;
		}

		public override void OnActionExecuting(ActionExecutingContext filterContext)
		{
			var controller = filterContext.Controller;
			if (controller != null)
			{
				var timer = Stopwatch.StartNew();
				controller.ViewData[ActionTimerPlaceholder] = timer;
			}
			base.OnActionExecuting(filterContext);
		}

		public override void OnActionExecuted(ActionExecutedContext filterContext)
		{
			var controller = filterContext.Controller;

			// ReSharper disable once UseNullPropagation
			if (controller == null) return;

			var timer = (Stopwatch)controller.ViewData[ActionTimerPlaceholder];

			if (timer == null) return;

			timer.Stop();
			controller.ViewData[ViewDataKey] = (int?)timer.ElapsedMilliseconds;
		}
	}
}