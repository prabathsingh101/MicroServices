using Microsoft.EntityFrameworkCore;
using PayrollService.Data;
using PayrollService.Models;

namespace PayrollService.GlobalErrorHandle
{
    public class GlobalErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<GlobalErrorHandlingMiddleware> _logger;

        public GlobalErrorHandlingMiddleware(RequestDelegate next, ILogger<GlobalErrorHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, EmployeeDbContext dbContext)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unhandled exception occurred.");
                await LogErrorToDatabase(context, ex, dbContext);
                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task LogErrorToDatabase(HttpContext context, Exception ex, EmployeeDbContext dbContext)
        {
            var errorLog = new ErrorLog
            {
                Message = ex.Message,
                StackTrace = ex.StackTrace,
                Source = ex.Source,
                Path = context.Request.Path,
                Method = context.Request.Method,
                QueryString = context.Request.QueryString.ToString()
            };

            dbContext.ErrorLogs.Add(errorLog);
            await dbContext.SaveChangesAsync();
        }

        private Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;

            var errorResponse = new
            {
                StatusCode = context.Response.StatusCode,
                Message = "An unexpected error occurred.",
                Detailed = ex.Message // Remove this in production if you want less verbose errors
            };

            return context.Response.WriteAsJsonAsync(errorResponse);
        }
    }
}
