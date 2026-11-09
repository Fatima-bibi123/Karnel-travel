using System;
namespace KarnelTravelGuide.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string OrderType { get; set; }
        public string Location { get; set; }
        public string CheckInDate { get; set; }
        public int Quantity { get; set; }
        public string Details { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public string Status { get; set; } = "Pending";
    }
}