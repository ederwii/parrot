using PR.Data.Models;
using PR.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR.Data.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly OrderDbContext _context;

        public OrderRepository(OrderDbContext context)
        {
            _context = context;
        }

        public void Create(Domain.Models.Order order)
        {
            var newOrder = new Order();
            _context.Orders.Add(newOrder);
            _context.SaveChanges();
        }
    }
}
