using Generic.Repo.API.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Generic.Repo.API.Repositories
{
    public interface IOrderRepo : IGenericRepo<Order>
    {
        Task<IEnumerable<Order>> GetAllOrdersAsync();
        Task<Order> GetOrderByIdAsync(int id);
        Task<Order> InsertOrderAsync(Order order);
        Task<Order> DeleteOrderAsync(int id);
        Task<Order> UpdateOrderAsync(int id, Order order);
        Task<int> SaveAsync();

        Task<IEnumerable<Order>> GetOrdersByUserId(int id);
    }
}
