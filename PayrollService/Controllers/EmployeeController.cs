using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using PayrollService.Models;
using PayrollService.Repositories.Interface;
using PayrollService.SharedResource;


namespace PayrollService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployee employee;
        private readonly IStringLocalizer<SharedResource.SharedResource> _stringLocalizer;

        public EmployeeController(IEmployee employee, IStringLocalizer<SharedResource.SharedResource> stringLocalizer)
        {
            this.employee = employee;
            _stringLocalizer = stringLocalizer;
        }

        [HttpGet]
        [Route("GetEmployee")]
        public async Task<IActionResult> GetEmployee()
        {
            var result = await employee.GetAllAsync();

            if (result.Count == 0)            
                throw new Exception("This is a test exception.");            

            if (result != null && result?.Count > 0)
            {

                var responses = new DataResponse
                {
                    Message = "STATUS_DATA_FOUND" ?? "",
                    StatusCode = ErrorStatusCode.STATUS_SUCCESS,
                    IsSuccess = true,
                    Result = result
                };
                return Ok(responses);
            }
            else
            {
                var responses = new DataResponse
                {
                    Message = "STATUS_DATA_FAIL" ?? "",
                    StatusCode = ErrorStatusCode.STATUS_BadRequest,
                    IsSuccess = false,
                    Result = result
                };
                return Ok(responses);
            }
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
