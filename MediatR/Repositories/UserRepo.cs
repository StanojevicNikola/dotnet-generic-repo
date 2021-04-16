using Generic.Repo.API.Database;
using Generic.Repo.API.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Generic.Repo.API.Repositories
{
    public class UserRepo : GenericRepo<User>, IUserRepo
    {
        public UserRepo(DBContext dbContext) : base(dbContext)
        {
        }

        public async Task<User> DeleteUserAsync(int id)
        {
            return await Delete(id);
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await GetAll();
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await GetById(id);
        }

        public async Task<User> InsertUserAsync(User user)
        {
            return await Insert(user);
        }

        public async Task<int> SaveAsync()
        {
            return await Save(); 
        }

        public async Task<User> UpdateUserAsync(int id, User user)
        {
            return await Update(id, user);
        }
    }
}
