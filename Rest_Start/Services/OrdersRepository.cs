using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rest_Start.Data;
using Rest_Start.Models;

namespace Rest_Start.Services
{
    public class OrdersRepository : IOrderRepository
    {
        private readonly AppDbContext _context;

        public OrdersRepository(AppDbContext context)
        {
            _context = context;
        }
        public void AddOrder(Order product)
        {
            var ore = new Order { OrderName = "Order 1", Price = 500 };
            _context.Orders.Add(ore);
            _context.SaveChanges();
        }

        public void DeleteOrder(int id)
        {
            throw new NotImplementedException();
        }
    }
}
