using Generic.Repo.API.Domain;
using Generic.Repo.API.Mapping.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Generic.Repo.API.Services
{
    public interface IOrderService
    {
        Task<IEnumerable<OrderReadDto>> GetAllOrdersAsync();
        Task<OrderReadDto> GetOrderByIdAsync(int id);
        Task<OrderReadDto> InsertOrderAsync(OrderCreateDto order);
        Task<OrderReadDto> DeleteOrderAsync(int id);
        Task<OrderReadDto> UpdateOrderAsync(int id, OrderCreateDto order);
        Task<int> SaveAsync();

        Task<IEnumerable<OrderReadDto>> GetOrdersByUserId(int id);

    }
}
