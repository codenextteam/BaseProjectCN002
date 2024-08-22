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
        private readonly IProductImageService _productImageService;
        private readonly IServiceHeadService _serviceHeadService;
        public HomeController(ILogger<HomeController> logger, IProductService productService, IServiceHeadService serviceHeadService, IProductImageService productImageService)
        {
            _logger = logger;
            _productService = productService;
            _serviceHeadService = serviceHeadService;
            _productImageService = productImageService;
        }

        public IActionResult Index()
        {
           HomeVM vm = new HomeVM 
           {
               Products = _productService.GetAllProducts().Data,
               ProductsGetByIsFeatured = _productService.GetAllProductsByIsFeatured().Data,
               GetServiceHeads = _serviceHeadService.GetServiceHead().Data,
               ProductImages = _productImageService.GetAllProductImages().Data,
           };
            return View(vm);
        }
 
   
        public IActionResult Privacy()
        {
            return View();
        }

       
       
    }
}
