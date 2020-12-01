using Loftysoft.Demo.Contracts;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Loftysoft.Demo.Web.Controllers
{
	[ActionTimer]
	public class HomeController : Controller
	{
		private readonly IMessageRepository messageRepository;

		private readonly Random random;

		public HomeController(IMessageRepository messageRepository)
		{
			this.messageRepository = messageRepository;
			random = new Random(DateTime.Now.Second);
		}

		public async Task<ActionResult> Index()
		{
			if (Request.QueryString.HasKeys())
			{
				SetViewBagDataFromQuery();
			}

			var randomValue = random.Next(1, 10);
			if (randomValue <= 3)
			{
				await Task.Delay(TimeSpan.FromMilliseconds(random.Next(1, 1500)));
			}

			return View();
		}

		[HttpPost, ActionName("Index")]
		public async Task<ActionResult> MessagePost(string name, string message)
		{
			await messageRepository.AddMessageAsync(name, message, Request.UserHostAddress);

			var responseUrl = Request.Url.AbsoluteUri.Split('?').First();
			return Redirect($"{responseUrl}?{Query.MessageKey}={Query.MessageSentValue}");
		}

		public ActionResult About()
		{
			ViewBag.Message = "Your application description page.";

			var randomValue = random.Next(1, 10);
			if (randomValue <= 3)
			{
				var exception = new Exception("Oh oh...!");
				throw exception;
			}
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
				ViewBag.PageMessage = $"Message sent to Magnus (UTC {DateTime.UtcNow.ToString("T")})!";
			}
		}
	}
}