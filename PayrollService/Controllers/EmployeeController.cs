using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PayrollService.Models;
using PayrollService.Repositories.Interface;

namespace PayrollService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployee employee;

        public EmployeeController(IEmployee employee)
        {
            this.employee = employee;
        }

        [HttpGet]
        [Route("GetEmployee")]
        public async Task<IActionResult> GetEmployee()
        {
            var model = await employee.GetAllAsync();
            return Ok(model);   
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var model = await employee.GetByIdAsync(id);

            if (model == null)
            {
                return NotFound();
            }

            return Ok(model);
        }
        [HttpPost]
        [Route("post")]
        [Produces("application/json")]
        public async Task<IActionResult> Create([FromBody] EmployeeModel model)
        {

            var domainModel = await employee.CreateAsync(model);

           return Ok(domainModel);
        }

        [HttpDelete]
        [Route("{id:int}")]
        [Produces("application/json")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var model = await employee.DeleteAsync(id);
            if (model == null)
            {
                return NotFound();
            }
            return Ok(model);
        }

        [HttpPut]
        [Route("{id:int}")]
        [Produces("application/json")]
        public async Task<IActionResult> Update([FromRoute] int id,
                                              [FromBody] EmployeeModel employeeModel)
        {
            var result = await employee.UpdateAsync(id, employeeModel);

            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}
