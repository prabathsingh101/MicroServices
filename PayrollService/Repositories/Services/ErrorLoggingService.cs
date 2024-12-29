using PayrollService.Data;
using PayrollService.Models;
using PayrollService.Repositories.Interface;

namespace PayrollService.Repositories.Services
{
    public class ErrorLoggingService : IErrorLoggingService
    {
        private readonly EmployeeDbContext _employeeDbContext;
        private readonly HttpContext _context;

        public ErrorLoggingService(EmployeeDbContext employeeDbContext, HttpContext context)
        {
            _employeeDbContext = employeeDbContext;
            _context = context;
        }
        public async Task LogErrorAsync(Exception ex, string source, string method)
        {
            var errorLog = new ErrorLog
            {
                Message = ex.Message,
                StackTrace= ex.StackTrace,
                Source = source,
                Method = method,  
                Path=_context.Request.Path,
            };
            _employeeDbContext.ErrorLogs.Add(errorLog);
            await _employeeDbContext.SaveChangesAsync();
        }
    }
}
