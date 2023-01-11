using Microsoft.AspNetCore.Mvc;

namespace StarbucksProje.Controllers
{
	public class ErrorPageController : Controller
	{
		public IActionResult Errors(int code)
		{
			ViewBag.Code = code;
			return View();
		}
	}
}
