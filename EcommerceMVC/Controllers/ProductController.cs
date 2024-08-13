using Business.Abstract;
using EcommerceMVC.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceMVC.Controllers
{
	public class ProductController : Controller
	{
		private readonly IProductService _productService;

		public ProductController(IProductService productService)
		{
			_productService = productService;
		}

		public IActionResult Index()
		{
			return View();
		}

		public IActionResult ProductDetail(int id)
		{
			HomeVM vm = new HomeVM
			{
				Product = _productService.GetProductById(id).Data,
			};
			if (vm.Product != null)
			{
				return View(vm);
			}
			else
			{
				return NotFound();
			}
		}
	}
}
