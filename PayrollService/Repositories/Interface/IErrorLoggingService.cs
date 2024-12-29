namespace PayrollService.Repositories.Interface
{
    public interface IErrorLoggingService
    {
        Task LogErrorAsync(Exception ex,string source,string method);
    }
}
