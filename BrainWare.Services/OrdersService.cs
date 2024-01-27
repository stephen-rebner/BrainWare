using System.Collections.Generic;
using System.Linq;
using BrainWare.Dal;
using BrainWare.Services.Models;

namespace BrainWare.Services
{
    public class OrdersService
    {
        public IList<OrderDto> GetOrdersByCompanyId(int companyId)
        {
            var repository = new OrderRepository();
            var orders = repository.GetOrdersByCompanyId(companyId);

            return orders
                .Select(order => new OrderDto
                {
                    OrderId = order.OrderId,
                    CompanyName = order.CompanyName,
                    Description = order.Description,
                    OrderTotal = order.OrderProducts.Sum(op => op.Price * op.Quantity),
                    OrderProducts = order.OrderProducts.Select(op => new OrderProductDto
                    {
                        OrderId = op.OrderId,
                        ProductId = op.ProductId,
                        Product = new ProductDto
                        {
                            Name = op.Product.Name,
                            Price = op.Product.Price
                        },
                        Quantity = op.Quantity,
                        Price = op.Price
                    }).ToList()
                }).ToList();
        }
    }
}