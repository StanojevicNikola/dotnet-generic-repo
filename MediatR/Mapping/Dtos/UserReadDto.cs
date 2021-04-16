using System.Collections.Generic;

namespace Generic.Repo.API.Mapping.Dtos
{
    public class UserReadDto
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public string Name { get; set; }

        public IEnumerable<OrderReadDto> Orders { get; set; }
    }
}
