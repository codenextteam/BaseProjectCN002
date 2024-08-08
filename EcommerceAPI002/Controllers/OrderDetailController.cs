using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceAPI002.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailController(IOrderDetailService orderDetailService) : ControllerBase
    {
        private readonly IOrderDetailService _orderDetailService = orderDetailService;

        [HttpPost("AddOrderDetail")]
        public IActionResult Add(OrderDetail orderDetail)
        {
            var result = _orderDetailService.Add(orderDetail);
            if (result.Success)
            {
                return Ok(result);
            }
            else return BadRequest(result);
        }

        [HttpGet("GetAllOrderDetails")]
        public IActionResult GetAll()
        {
            var result = _orderDetailService.GetAllOrderDetails();
            if (result.Success)
            {
                return Ok(result);
            }
            else return BadRequest(result);
        }
    }
}
