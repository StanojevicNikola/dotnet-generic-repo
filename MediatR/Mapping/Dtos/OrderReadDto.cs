using System;

namespace Generic.Repo.API.Mapping.Dtos
{
    public class OrderReadDto
    {
        public int Id { get; set; }

        public string ProductName { get; set; }

        public string DeliveryAddress { get; set; }

        public DateTime Date { get; set; }

        public float Price { get; set; }
    }
}
