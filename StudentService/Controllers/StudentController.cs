using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentService.DBModels;
using StudentService.Response;

namespace StudentService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly StudentDbContext studentDbContext;

        public StudentController(StudentDbContext studentDbContext)
        {
            this.studentDbContext = studentDbContext;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var parentData = await studentDbContext.StudentMasters
                .Include(p => p.StudentDetails)
                .Select(p => new StudentResponse
                {
                    StudentID = p.StudentId,
                    StudentName = p.StudentName,
                    StudentDetails = p.StudentDetails.Select(c => new StudentDetailsResponse
                    {
                        DetailsId = Convert.ToInt32(c.DetailsId),
                        StudentID = Convert.ToInt32(c.StudentId),
                        SubjectName = c.SubjectName

                    }).ToList()
                })
                .ToListAsync();

            return Ok(parentData);
        }
    }
}
