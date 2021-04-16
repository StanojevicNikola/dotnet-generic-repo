using Generic.Repo.API.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Generic.Repo.API.Repositories
{
    public interface IUserRepo : IGenericRepo<User>
    {
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User> GetUserByIdAsync(int id);
        Task<User> InsertUserAsync(User user);
        Task<User> DeleteUserAsync(int id);
        Task<User> UpdateUserAsync(int id, User user);
        Task<int> SaveAsync();
    }
}
