using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EF;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceAPI002.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("getName")]
        public string GetName()
        {
            return "Murad";
        }

        [HttpGet("getAllProduct")]
        public IActionResult GetAllProducts()
        {
           var result = _productService.GetAllProducts();
            if (result.Success)
            {
                return Ok(result);
            }
            else return BadRequest(result);
        }

        [HttpGet("getProduct")]
        public IActionResult GetProduct(int id) 
        {
            var result = _productService.GetProductById(id);
            if (result.Success) 
            {
                return Ok(result);
            }
            else return BadRequest(result.Message);
        }

        [HttpPost("Addproduct")]
        public IActionResult Add(Product product)
        {
            var result = _productService.AddProduct(product);
            if (result.Success) 
            {
                return Ok(result);
            }
            else return BadRequest(result);
        }
       
    }
}
