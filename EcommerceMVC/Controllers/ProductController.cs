using Business.Abstract;
using EcommerceMVC.ViewModels;
using Entities.Dto;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceMVC.Controllers
{
	public class ProductController : Controller
	{
		private readonly IProductService _productService;
		private readonly IProductImageService _productImageService;
		public ProductController(IProductService productService, IProductImageService productImageService)
		{
			_productService = productService;
			_productImageService = productImageService;
		}

		public IActionResult Index()
		{
			return View();
		}
		public IActionResult Add()
		{
			return View();
		}
		[HttpPost]
		public IActionResult Add(ProductImageAddDto productImageAddDto)
		{
			try
			{
				_productImageService.AddProductImage(productImageAddDto);
				return RedirectToAction(nameof(Index));
			}
			catch (Exception)
			{
				return View();
			}
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
