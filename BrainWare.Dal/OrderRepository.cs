using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using BrainWare.Dal.Models;
using Dapper;

namespace BrainWare.Dal
{


    public class OrderRepository : IOrderRepository
    {
        public List<Order> GetOrdersByCompanyId(int companyId)
        {
            using (var connection =
                   new SqlConnection("Data Source=localhost;Initial Catalog=BrainWAre;Integrated Security=SSPI;"))
            {
                var builder = new SqlBuilder();
                var template = builder.AddTemplate(
                    @"  select 
                  o.order_id as OrderId,
                  c.name as CompanyName,
                  o.Description,               
                  op.order_id as OrderId,
                  op.product_id as ProductId,
                  op.quantity as Quantity, 
                  op.price as Price,
                  p.product_id as ProductId,
                  p.name as Name, 
                  p.price as Price
                  from [Order] o
                  inner join OrderProduct op on op.order_id = o.order_id
                  inner join Product p on p.product_id = op.product_id
                  inner join Company c on c.company_id = o.company_id
                  /**where**/");

                builder.Where("o.company_Id = @CompanyId", new { CompanyId = companyId });

                var orderDictionary = new Dictionary<int, Order>();

                connection.Query<Order, OrderProduct, Product, Order>(
                    template.RawSql,
                    param: template.Parameters,
                    map: (order, orderProduct, product) =>
                    {
                        Order orderEntry;

                        if (!orderDictionary.TryGetValue(order.OrderId, out orderEntry))
                        {
                            orderEntry = order;
                            orderEntry.OrderProducts = new List<OrderProduct>();
                            orderDictionary.Add(orderEntry.OrderId, orderEntry);
                        }

                        orderProduct.Product = product;
                        orderEntry.OrderProducts.Add(orderProduct);
                        return orderEntry;
                    },
                    splitOn: "OrderId,ProductId"
                );

                return orderDictionary.Values.ToList();
            }
        }


    }

    public interface IOrderRepository
    {
        List<Order> GetOrdersByCompanyId(int companyId);
    }
}