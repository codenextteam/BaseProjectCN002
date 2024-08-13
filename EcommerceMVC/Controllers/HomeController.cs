using Business.Abstract;
using EcommerceMVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EcommerceMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductService _productService;
        private readonly IServiceHeadService _serviceHeadService;
		public HomeController(ILogger<HomeController> logger, IProductService productService, IServiceHeadService serviceHeadService)
		{
			_logger = logger;
			_productService = productService;
			_serviceHeadService = serviceHeadService;
		}

		public IActionResult Index()
        {
           HomeVM vm = new HomeVM 
           {
               Products = _productService.GetAllProducts().Data,
               ProductsGetByIsFeatured = _productService.GetAllProductsByIsFeatured().Data,
               GetServiceHeads = _serviceHeadService.GetServiceHead().Data,
           };
            return View(vm);
        }
 
   
        public IActionResult Privacy()
        {
            return View();
        }

       
       
    }
}
