using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderServices.API.Repository.Interface;

namespace OrderServices.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {

        private readonly IOrders _order;
        public OrdersController(IOrders orders)
        {
              _order = orders;    
        }

        [HttpGet]
        [Route("AllOrder")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _order.GetAllAsync();
            return Ok(result);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _order.GetByIdAsync(id);
            return Ok(result);
        }
    }
}
