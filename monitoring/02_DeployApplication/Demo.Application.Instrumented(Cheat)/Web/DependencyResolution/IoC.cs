using Loftysoft.Demo.Lib;
using StructureMap;

namespace Loftysoft.Demo.Web.DependencyResolution
{
	public static class IoC
	{
		public static IContainer Initialize()
		{
			var container = new Container();

			container.Configure(c =>
			{
				c.Scan(scan =>
				{
					scan.TheCallingAssembly();
					scan.WithDefaultConventions();
				});

				// Loftysoft.Demo.Lib.dll
				c.IncludeRegistry<LibRegistry>();
            });

			return container;
		}
	}
}