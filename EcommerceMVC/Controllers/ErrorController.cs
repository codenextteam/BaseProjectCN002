using EcommerceMVC.ViewModels;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceMVC.Controllers
{
	public class ErrorController : Controller
	{
		[Route("Error/{statusCode}")]
		public IActionResult Error(int statusCode)
		{
			var feature = HttpContext.Features.Get<IStatusCodeReExecuteFeature>();

			return View(new ErrorVM { StatusCode = statusCode});
		}
	}
}
