using Microsoft.EntityFrameworkCore;
using OrderServices.API.Data;
using OrderServices.API.Models;
using OrderServices.API.Repository.Interface;

namespace OrderServices.API.Repository.Implementation
{
    public class Orders : IOrders
    {
        private readonly AppDBContext _dbContext;   
        public Orders(AppDBContext dBContext)
        {
              _dbContext = dBContext;  
        }

        public async Task<Order> Create(Order order)
        {
            await _dbContext.Orders.AddAsync(order);
            await _dbContext.SaveChangesAsync();
            return order;

        }

        public async Task<List<Order>> GetAllAsync()
        {
            return await _dbContext.Orders.AsNoTracking().ToListAsync();
        }

        public async Task<Order?> GetByIdAsync(int id)
        {
            return await _dbContext.Orders.AsNoTracking().SingleOrDefaultAsync(e => e.Id == id);
        }
    }
}
