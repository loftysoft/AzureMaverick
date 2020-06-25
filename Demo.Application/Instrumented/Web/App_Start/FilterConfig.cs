using System.Web.Mvc;

namespace Loftysoft.Demo.Web
{
	public static class FilterConfig
	{
		public static void RegisterGlobalFilters(GlobalFilterCollection filters)
		{
			filters.Add(new HandleErrorAttribute());
			filters.Add(new AiHandleErrorAttribute());
		}
	}
}