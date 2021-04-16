using System;

namespace Generic.Repo.API.Domain
{
    public class Order
    {
        public int Id { get; set; }

        public string ProductName { get; set; }

        public string DeliveryAddress { get; set; }
        
        public DateTime Date { get; set; }

        public float Price { get; set; }

        public float Discount { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }
    }
}
