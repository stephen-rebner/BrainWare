// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Web;
// using BrainWare.Services.Models;
//
// namespace Web.Infrastructure
// {
//     using System.Data;
//
//     public class OrderService
//     {
//         public List<OrderDto> GetOrdersForCompany(int CompanyId)
//         {
//
//             var database = new Database();
//
//             // Get the orders
//             var sql1 =
//                 "SELECT c.name, o.description, o.order_id FROM company c INNER JOIN [order] o on c.company_id=o.company_id";
//
//             var reader1 = database.ExecuteReader(sql1);
//
//             var values = new List<OrderDto>();
//             
//             while (reader1.Read())
//             {
//                 var record1 = (IDataRecord) reader1;
//
//                 values.Add(new OrderDto()
//                 {
//                     CompanyName = record1.GetString(0),
//                     Description = record1.GetString(1),
//                     OrderId = record1.GetInt32(2),
//                     OrderProducts = new List<OrderProductDto>()
//                 });
//
//             }
//
//             reader1.Close();
//
//             //Get the order products
//             var sql2 =
//                 "SELECT op.price, op.order_id, op.product_id, op.quantity, p.name, p.price FROM orderproduct op INNER JOIN product p on op.product_id=p.product_id";
//
//             var reader2 = database.ExecuteReader(sql2);
//
//             var values2 = new List<OrderProductDto>();
//
//             while (reader2.Read())
//             {
//                 var record2 = (IDataRecord)reader2;
//
//                 values2.Add(new OrderProductDto()
//                 {
//                     OrderId = record2.GetInt32(1),
//                     ProductId = record2.GetInt32(2),
//                     Price = record2.GetDecimal(0),
//                     Quantity = record2.GetInt32(3),
//                     Product = new ProductDto()
//                     {
//                         Name = record2.GetString(4),
//                         Price = record2.GetDecimal(5)
//                     }
//                 });
//              }
//
//             reader2.Close();
//
//             foreach (var order in values)
//             {
//                 foreach (var orderproduct in values2)
//                 {
//                     if (orderproduct.OrderId != order.OrderId)
//                         continue;
//
//                     order.OrderProducts.Add(orderproduct);
//                     order.OrderTotal = order.OrderTotal + (orderproduct.Price * orderproduct.Quantity);
//                 }
//             }
//
//             return values;
//         }
//     }
// }