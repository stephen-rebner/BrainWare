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
                    OrderProducts = order.OrderProducts.Select(orderProduct => new OrderProductDto
                    {
                        OrderId = orderProduct.OrderId,
                        ProductId = orderProduct.ProductId,
                        ProductName = orderProduct.Product.Name,
                        ProductPrice = orderProduct.Product.Price,
                        Quantity = orderProduct.Quantity,
                        Price = orderProduct.Price
                    }).ToList()
                }).ToList();
        }
    }
}