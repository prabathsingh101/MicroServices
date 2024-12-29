using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PayrollService.Data;
using PayrollService.Repositories.Interface;

namespace PayrollService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DesignationController : ControllerBase
    {
        private readonly IEmployee employee;
        private readonly ILogger<DesignationController> logger;

        public DesignationController(IEmployee employee, 
            ILogger<DesignationController> logger
            )
        {
            this.employee = employee;
            this.logger = logger;
        }
        [HttpGet]
        [Route("Designation")]
        public async Task<IActionResult> GetDesignation()
        {
            var result = await employee.GetAllAsync();

            if (result.Count == 0)
                throw new Exception("This is a test exception.");
            return Ok(result);
        }
    }
}
