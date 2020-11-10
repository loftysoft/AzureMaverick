using Loftysoft.Demo.Contracts;
using StructureMap;

namespace Loftysoft.Demo.Lib
{
	// ReSharper disable once UnusedMember.Global
	public class LibRegistry : Registry
	{
		public LibRegistry()
		{
			For<IMessageRepository>().Use<NullMessageRepository>();
		}
	}
}