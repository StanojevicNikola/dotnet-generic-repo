using AutoMapper;
using Generic.Repo.API.Domain;
using Generic.Repo.API.Mapping.Dtos;
using Generic.Repo.API.Repositories;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Generic.Repo.API.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepo _orderRepo;
        private readonly IMapper _mapper;
        private readonly ILogger<OrderService> _logger;

        public OrderService(IOrderRepo orderRepo, IMapper mapper, ILogger<OrderService> logger)
        {
            _orderRepo = orderRepo;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<OrderReadDto> DeleteOrderAsync(int id)
        {
            Order result;

            try
            {
                result = await _orderRepo.DeleteOrderAsync(id);
                _logger.LogInformation($"[Success] Delete order at {DateTime.Now}");
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"[Error] Delete order at {DateTime.Now}: {ex.Message}");
                throw new ArgumentNullException(nameof(result));
            }

            return _mapper.Map<OrderReadDto>(result);
        }

        public async Task<IEnumerable<OrderReadDto>> GetAllOrdersAsync()
        {
            IEnumerable<Order> result;

            try
            {
                result = await _orderRepo.GetAllOrdersAsync();
                _logger.LogInformation($"[Success] Get all orders at {DateTime.Now}");
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"[Error] Get all orders at {DateTime.Now}: {ex.Message}");
                throw new ArgumentNullException(nameof(result));
            }

            return _mapper.Map<IEnumerable<OrderReadDto>>(result);
        }

        public async Task<OrderReadDto> GetOrderByIdAsync(int id)
        {
            Order result;

            try
            {
                result = await _orderRepo.GetOrderByIdAsync(id);
                _logger.LogInformation($"[Success] Get order by Id at {DateTime.Now}");
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"[Error] Get order by Id at {DateTime.Now}: {ex.Message}");
                throw new ArgumentNullException(nameof(result));
            }

            return _mapper.Map<OrderReadDto>(result);
        }

        public async Task<OrderReadDto> InsertOrderAsync(OrderCreateDto dto)
        {
            Order result;

            try
            {
                var user = _mapper.Map<Order>(dto);
                result = await _orderRepo.InsertOrderAsync(user);

                _logger.LogInformation($"[Success] Insert order at {DateTime.Now}");
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"[Error] Insert order at {DateTime.Now}: {ex.Message}");
                throw new ArgumentNullException(nameof(result));
            }

            return _mapper.Map<OrderReadDto>(result);
        }

        public async Task<int> SaveAsync()
        {
            return await _orderRepo.SaveAsync();
        }

        public async Task<OrderReadDto> UpdateOrderAsync(int id, OrderCreateDto dto)
        {
            Order result;

            try
            {
                var user = _mapper.Map<Order>(dto);
                result = await _orderRepo.UpdateOrderAsync(id, user);

                _logger.LogInformation($"[Success] Update order at {DateTime.Now}");
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"[Error] Update order at {DateTime.Now}: {ex.Message}");
                throw new ArgumentNullException(nameof(result));
            }

            return _mapper.Map<OrderReadDto>(result);
        }

        public async Task<IEnumerable<OrderReadDto>> GetOrdersByUserId(int id)
        {
            IEnumerable<Order> orders = await _orderRepo.GetAllOrdersAsync();
            var dto = orders.Where(o => o.UserId == id);
            
            return _mapper.Map<IEnumerable<OrderReadDto>>(dto);
        }
    }
}
