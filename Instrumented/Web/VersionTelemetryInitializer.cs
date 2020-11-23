using Microsoft.ApplicationInsights.Channel;
using Microsoft.ApplicationInsights.Extensibility;

namespace Loftysoft.Demo.Web
{
	public class VersionTelemetryInitializer : ITelemetryInitializer
	{
		private readonly string version;

		public VersionTelemetryInitializer(string version)
		{
			this.version = version;
		}

		public void Initialize(ITelemetry telemetry)
		{
			//telemetry.Context.Properties.Add("App Version", version);
		}
	}
}