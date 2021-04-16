using Generic.Repo.API.Domain;
using Microsoft.EntityFrameworkCore;

namespace Generic.Repo.API.Database
{
    public class DBContext : DbContext 
    {
        public DBContext(DbContextOptions options) : base(options)
        {
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
    }
}
