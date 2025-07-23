using OrderServices.API.Models;

namespace OrderServices.API.Repository.Interface
{
    public interface IOrders
    {
        Task<List<Order>> GetAllAsync();

        Task<Order?> GetByIdAsync(int id);

        Task<Order> Create(Order order);    

        //Task<Order> Update(Order order);

        //Task<Order?> DeleteAsync(int id);
    }
}
