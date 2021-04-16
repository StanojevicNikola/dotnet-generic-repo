using Generic.Repo.API.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Generic.Repo.API.Repositories
{
    public interface IGenericRepo<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
        Task<T> Insert(T one);
        Task<T> Delete(int id);
        Task<T> Update(int id, T one);
        Task<int> Save();
    }
}
