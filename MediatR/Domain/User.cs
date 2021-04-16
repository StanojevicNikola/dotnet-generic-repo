using System.Collections.Generic;

namespace Generic.Repo.API.Domain
{
    public class User
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public IEnumerable<Order> Orders { get; set; }
    }
}
