using Microsoft.EntityFrameworkCore;
using PayrollService.Models;

namespace PayrollService.Data
{
    public class EmployeeDbContext: DbContext
    {
        public EmployeeDbContext()
        {
        }

        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options)
            : base(options)
        {
        }

        public DbSet<EmployeeModel> Employees { get; set; }
        public DbSet<ErrorLog> ErrorLogs { get; set; }
    }
}
