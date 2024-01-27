using System.Collections.Generic;

namespace BrainWare.Services.Models
{
    public class OrderDto
    {
        public int OrderId { get; set; }

        public string CompanyName { get; set; }

        public string Description { get; set; }

        public decimal OrderTotal { get; set; }

        public List<OrderProductDto> OrderProducts { get; set; }

    }


    public class OrderProductDto
    {
        public int OrderId { get; set; }

        public int ProductId { get; set; }

        public ProductDto Product { get; set; }
    
        public int Quantity { get; set; }

        public decimal Price { get; set; }

    }

    public class ProductDto
    {
        public string Name { get; set; }

        public decimal Price { get; set; }
    }
}