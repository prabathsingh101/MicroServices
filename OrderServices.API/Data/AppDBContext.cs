using Microsoft.EntityFrameworkCore;
using OrderServices.API.Models;

namespace OrderServices.API.Data
{
    public class AppDBContext: DbContext
    {
        public AppDBContext()
        {
        }

        public AppDBContext(DbContextOptions<AppDBContext> options)
            : base(options)
        {
        }

        public DbSet<Order> Orders { get; set; }
    }
}
