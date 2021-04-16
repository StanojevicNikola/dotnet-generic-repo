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
    public class UserService : IUserService
    {
        private readonly IUserRepo _userRepo;
        private readonly IOrderRepo _orderRepo;
        private readonly IMapper _mapper;
        private readonly ILogger<UserService> _logger;

        public UserService(IUserRepo userRepo, IOrderRepo orderRepo, IMapper mapper, ILogger<UserService> logger)
        {
            _userRepo = userRepo;
            _orderRepo = orderRepo;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<UserReadDto> DeleteUserAsync(int id)
        {
            User result;

            try
            {
                result = await _userRepo.DeleteUserAsync(id);
                _logger.LogInformation($"[Success] Delete user at {DateTime.Now}");
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"[Error] Delete user at {DateTime.Now}: {ex.Message}");
                throw new ArgumentNullException(nameof(result));
            }

            return _mapper.Map<UserReadDto>(result);
        }

        public async Task<IEnumerable<UserReadDto>> GetAllUsersAsync()
        {
            IEnumerable<User> users;
            
            try
            {
                IEnumerable<Order> orders = await _orderRepo.GetAllOrdersAsync();
                
                users = await _userRepo.GetAllUsersAsync();
                users.Select(u => u.Orders = orders.Where(o => o.UserId == u.Id)); 

                _logger.LogInformation($"[Success] Get all users at {DateTime.Now}");
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"[Error] Get all users at {DateTime.Now}: {ex.Message}");
                throw new ArgumentNullException(nameof(users));
            }

            return _mapper.Map<IEnumerable<UserReadDto>>(users);
        }

        public async Task<UserReadDto> GetUserByIdAsync(int id)
        {
            User result;

            try
            {
                result = await _userRepo.GetUserByIdAsync(id);
                result.Orders = await _orderRepo.GetOrdersByUserId(id);

                _logger.LogInformation($"[Success] Get user by Id at {DateTime.Now}");
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"[Error] Get user by Id at {DateTime.Now}: {ex.Message}");
                throw new ArgumentNullException(nameof(result));
            }

            return _mapper.Map<UserReadDto>(result);
        }

        public async Task<UserReadDto> InsertUserAsync(UserCreateDto dto)
        {
            User result;

            try
            {
                var user = _mapper.Map<User>(dto);
                result = await _userRepo.InsertUserAsync(user);

                _logger.LogInformation($"[Success] Insert user at {DateTime.Now}");
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"[Error] Insert user at {DateTime.Now}: {ex.Message}");
                throw new ArgumentNullException(nameof(result));
            }

            return _mapper.Map<UserReadDto>(result);
        }

        public async Task<int> SaveAsync()
        {
            return await _userRepo.SaveAsync();
        }

        public async Task<UserReadDto> UpdateUserAsync(int id, UserCreateDto dto)
        {
            User result;

            try
            {
                var user = _mapper.Map<User>(dto);
                result = await _userRepo.UpdateUserAsync(id, user);

                _logger.LogInformation($"[Success] Update user at {DateTime.Now}");
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"[Error] Update user at {DateTime.Now}: {ex.Message}");
                throw new ArgumentNullException(nameof(result));
            }

            return _mapper.Map<UserReadDto>(result);
        }
    }
}
