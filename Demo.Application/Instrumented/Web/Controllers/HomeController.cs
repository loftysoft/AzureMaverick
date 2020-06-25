using Loftysoft.Demo.Contracts;
using Microsoft.ApplicationInsights;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Loftysoft.Demo.Web.Controllers
{
	[ActionTimer]
	public class HomeController : Controller
	{
		private readonly IMessageRepository messageRepository;
		private static TelemetryClient telemetry;
		private readonly Random random;

		public HomeController(IMessageRepository messageRepository)
		{
			this.messageRepository = messageRepository;
			random = new Random(DateTime.Now.Second);
		}

		private static TelemetryClient TelemetryClient => telemetry ?? (telemetry = new TelemetryClient());

		public async Task<ActionResult> Index()
		{
      var indexTimer = Stopwatch.StartNew();
			TelemetryClient.TrackMetric("Calls To Home", 1);

			if (Request.QueryString.HasKeys())
			{
				SetViewBagDataFromQuery();
			}

			var randomValue = random.Next(1, 10);
			if (randomValue <= 3)
			{
				await Task.Delay(TimeSpan.FromMilliseconds(random.Next(1, 1500)));
			}

			TelemetryClient.TrackMetric("IndexTime", indexTimer.ElapsedMilliseconds);
			return View();
		}

		[HttpPost, ActionName("Index")]
		public async Task<ActionResult> MessagePost(string name, string message)
		{
			TelemetryClient.TrackTrace(name + " says: '" + message + "'");

			await messageRepository.AddMessageAsync(name, message, Request.UserHostAddress);

			// ReSharper disable once PossibleNullReferenceException
			var responseUrl = Request.Url.AbsoluteUri.Split('?').First();
			return Redirect($"{responseUrl}?{Query.MessageKey}={Query.MessageSentValue}");
		}

		public ActionResult About()
		{
			TelemetryClient.TrackEvent("StartAbout");

			ViewBag.Message = "Your application description page.";

			var randomValue = random.Next(1, 10);
			if (randomValue <= 3)
			{
				var exception = new Exception("Oh oh...!");
				TelemetryClient.TrackException(exception);
				throw exception;
			}

			TelemetryClient.TrackEvent("EndAbout");
			return View();
		}

		private static class Query
		{
			public const string MessageKey = "Message";
			public const string MessageSentValue = "MessageSent";
		}

		private void SetViewBagDataFromQuery()
		{
			if (Request.QueryString.Keys.Cast<string>().Any(k => k == Query.MessageKey) &&
				Request.QueryString[Query.MessageKey] == "MessageSent")
			{
				ViewBag.PageMessage = $"Message sent to Magnus (UTC {DateTime.UtcNow.ToString("u")})!";
			}
		}
	}
}