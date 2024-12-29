using Microsoft.AspNetCore.Components.Web;

namespace PayrollService.GlobalErrorHandleMiddleware
{
    public class GlobalExceptionMiddleware
    {
        private readonly RequestDelegate next;
        private readonly IErrorBoundaryLogger errorloggingService;
        private readonly ILogger<GlobalExceptionMiddleware> logger;

        public GlobalExceptionMiddleware(
            RequestDelegate next,
            IErrorBoundaryLogger errorloggingService, 
            ILogger<GlobalExceptionMiddleware> logger
            )
        {
            this.next = next;
            this.errorloggingService = errorloggingService;
            this.logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await errorloggingService.LogErrorAsync(ex);
                logger.LogError(ex, "An error occured");
                context.Response.StatusCode = 500;
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(new
                {
                    Message = "An error occured while proccessing your request"
                }.ToString());
            }
        }
    }
}
