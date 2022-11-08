using Microsoft.AspNetCore.Mvc;

namespace UppyDemo
{
	public class HomeController : Controller
	{
		[Route("/")]
		public IActionResult Uppy()
		{
			return View();
		}
	}
}
