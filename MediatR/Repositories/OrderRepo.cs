using Generic.Repo.API.Database;
using Generic.Repo.API.Domain;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Generic.Repo.API.Repositories
{
    public class OrderRepo : GenericRepo<Order>, IOrderRepo
    {
        public OrderRepo(DBContext dbContext) : base(dbContext)
        {
        }

        public async Task<Order> DeleteOrderAsync(int id)
        {
            return await Delete(id);
        }

        public async Task<IEnumerable<Order>> GetAllOrdersAsync()
        {
            return await GetAll();
        }

        public async Task<Order> GetOrderByIdAsync(int id)
        {
            return await GetById(id);
        }

        public async Task<IEnumerable<Order>> GetOrdersByUserId(int id)
        {
            IEnumerable<Order> orders = await GetAllOrdersAsync();
            
            return orders.Where(o => o.UserId == id);
        }

        public async Task<Order> InsertOrderAsync(Order order)
        {
            return await Insert(order);
        }

        public async Task<int> SaveAsync()
        {
            return await Save(); 
        }

        public async Task<Order> UpdateOrderAsync(int id, Order order)
        {
            return await Update(id, order);
        }
    }
}
