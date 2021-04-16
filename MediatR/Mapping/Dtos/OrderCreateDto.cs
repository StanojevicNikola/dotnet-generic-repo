using System;

namespace Generic.Repo.API.Mapping.Dtos
{
    public class OrderCreateDto
    {
        public string ProductName { get; set; }

        public string DeliveryAddress { get; set; }

        public DateTime Date { get; set; }

        public float Price { get; set; }

        public float Discount { get; set; }

        public int UserId { get; set; }
    }
}
