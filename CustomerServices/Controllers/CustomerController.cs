using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CustomerServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        [HttpGet]

        public IActionResult GetOrders()
        {                      
           
            var orders= HttpContext.Items["ApiData1"] as string;

            return Ok(orders);
        }

        [HttpGet]
        [Route("product")]
        public IActionResult GetProduct()
        {

            var products = HttpContext.Items["ApiData2"] as string;

            return Ok(products);
        }
        //[HttpGet]
        //[Route("{id:int}")]
        //public IActionResult GetProductById(int id)        
        //{

        //    var products = HttpContext.Items["ApiData3"] as string;

        //    return Ok(products);
        //}
    }
}
