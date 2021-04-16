using Generic.Repo.API.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Generic.Repo.API.Repositories
{
    public class GenericRepo<T> : IGenericRepo<T> where T : class
    {
        private readonly DBContext _db;
        private readonly DbSet<T> _table;

        public GenericRepo(DBContext dbContext)
        {
            _db = dbContext;
            _table = dbContext.Set<T>();
        }

        public async Task<T> Insert(T one)
        {
            if (one == null)
                throw new ArgumentNullException($"[Error] Insert null entity.");

            try
            {
                await _table.AddAsync(one);
                await Save();
            }
            catch (Exception)
            {
                throw new ArgumentNullException($"[Error] Insert entity.");
            }
            
            return one;
        }

        public async Task<T> Delete(int id)
        {
            T existing;

            try
            {
                existing = await _table.FindAsync(id);
                if (existing == null)
                    throw new ArgumentNullException($"[Error] Delete null entity.");

                _table.Remove(existing);
                await Save();
            }
            catch (Exception)
            {
                throw new ArgumentNullException($"[Error] Delete entity.");
            }

            return existing;
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            try
            {
                return await _table.ToListAsync();
            }
            catch (Exception)
            {
                throw new ArgumentNullException($"[Error] GetAll entities.");
            }
        }

        public async Task<T> GetById(int id)
        {
            T existing;

            try
            {
                existing = await _table.FindAsync(id);
                if (existing == null)
                    throw new ArgumentNullException($"[Error] GetById null entity.");
            }
            catch (Exception)
            {
                throw new ArgumentNullException($"[Error] GetById entity.");
            }

            return existing;
        }

        public async Task<int> Save()
        {
            try
            {
                return await _db.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw new ArgumentNullException($"[Error] Save entity.");
            }
        }

        public async Task<T> Update(int id, T one)
        {
            T existing;

            try
            {
                existing = await _table.FindAsync(id);
                if (existing == null)
                    throw new ArgumentNullException($"[Error] Update null entity.");

                existing = UpdateObjectProperties<T>(existing, one);
                await Save();
            }
            catch (Exception)
            {
                throw new ArgumentNullException($"[Error] Update entity.");
            }

            return existing;
        }

        private U UpdateObjectProperties<U>(U dest, U src)
        {
            PropertyInfo[] properties = src.GetType().GetProperties();

            var notNullProperties = properties.ToList().FindAll(p => p.GetValue(src) != null);

            List<string> propertyNames = (from p in notNullProperties select p.Name).Skip(1).ToList();

            propertyNames.ToList().ForEach(p => Debug.WriteLine($"property: {p}" + "\n"));

            properties.Where(p => propertyNames.Contains(p.Name)).ToList()
                .ForEach(p => p.SetValue(dest, p.GetValue(src, null)));

            return dest;
        }
    }
}

       

      
