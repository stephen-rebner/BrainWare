using System.Collections.Generic;

namespace BrainWare.Dal.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public string CompanyName { get; set; }
        public string Description { get; set; }
        public List<OrderProduct> OrderProducts { get; set; } = new List<OrderProduct>();
    }
}