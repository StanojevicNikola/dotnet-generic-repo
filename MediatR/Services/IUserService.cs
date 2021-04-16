using Generic.Repo.API.Domain;
using Generic.Repo.API.Mapping.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Generic.Repo.API.Services
{
    public interface IUserService
    {
        Task<IEnumerable<UserReadDto>> GetAllUsersAsync();
        Task<UserReadDto> GetUserByIdAsync(int id);
        Task<UserReadDto> InsertUserAsync(UserCreateDto dto);
        Task<UserReadDto> UpdateUserAsync(int id, UserCreateDto dto);
        Task<UserReadDto> DeleteUserAsync(int id);
        Task<int> SaveAsync();
    }
}
