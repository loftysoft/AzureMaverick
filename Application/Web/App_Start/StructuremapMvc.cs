using System.Web.Http;
using System.Web.Mvc;
using Loftysoft.Demo.Web;
using Loftysoft.Demo.Web.DependencyResolution;
using StructureMap;

[assembly: WebActivator.PreApplicationStartMethod(typeof(StructuremapMvc), "Start")]

namespace Loftysoft.Demo.Web
{
	public static class StructuremapMvc
	{
		// ReSharper disable once UnusedMember.Global
		public static void Start()
		{
			IContainer container = IoC.Initialize();
			var structureMapDependencyResolver = new StructureMapDependencyResolver(container);
			DependencyResolver.SetResolver(structureMapDependencyResolver);
			GlobalConfiguration.Configuration.DependencyResolver = structureMapDependencyResolver;
		}
	}
}