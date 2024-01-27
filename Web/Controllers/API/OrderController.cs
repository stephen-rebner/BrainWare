using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BrainWare.Dal;
using BrainWare.Services.Models;

namespace Web.Controllers
{
    using System.Web.Mvc;
    using Infrastructure;

    public class OrderController : ApiController
    {
        private readonly IOrderRepository _orderRepository;
        
        
        [HttpGet]
        public IEnumerable<OrderDto> GetOrders(int id = 1)
        {
            var orderService = new BrainWare.Services.OrdersService();
            
            var orders = orderService.GetOrdersByCompanyId(id);
            
            return orders;
        }
    }
}
