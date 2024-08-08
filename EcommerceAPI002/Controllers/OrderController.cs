using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceAPI002.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost("AddOrder")]
        public IActionResult Add(Order order) 
        {
           var result =  _orderService.AddOrder(order);
            if (result.Success)
            {
                return Ok(result);
            }
            else return BadRequest(result);
        }
        [HttpGet("GetAllOrders")]
        public IActionResult GetAll()
        {
            var result = _orderService.GetAllOrders();
            if (result.Success)
            {
                return Ok(result);
            }
            else return BadRequest(result);
        }
    }
}
