using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductService.DBModels;

namespace ProductService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ProductMiniContext productMiniContext;

        public ProductsController(ProductMiniContext productMiniContext)
        {
            this.productMiniContext = productMiniContext;
        }
        [HttpGet]
        public async Task<ActionResult> GetProducts()
        {
            var result = await productMiniContext.Products.ToListAsync();            
            return Ok(result);
        }
     
        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult> GetProducts(int id)
        {
            var result = await productMiniContext.Products.Where(x=> x.Id == id).FirstOrDefaultAsync(); 
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}
