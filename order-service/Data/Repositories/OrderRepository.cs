using AutoMapper;
using Microsoft.EntityFrameworkCore;
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
        private IMapper _mapper;
        private readonly OrderDbContext _context;

        public OrderRepository(OrderDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Create(Domain.Models.Order order)
        {
            _context.Orders.Add(_mapper.Map<Order>(order));
            _context.SaveChanges();
        }

        public IEnumerable<Domain.Models.OrderProduct> GetOrderProducts(DateTime? startDate, DateTime? endDate)
        {
            var orders = _context.Orders.Include(x => x.OrderProducts).AsQueryable();
            if (startDate.HasValue)
                orders = orders.Where(o => o.OrderDate.Date >= startDate.Value.Date);

            if (endDate.HasValue)
                orders = orders.Where(o => o.OrderDate.Date <= endDate.Value.Date);

            var orderProducts = new List<OrderProduct>();

            foreach(var order in orders)
            {
                orderProducts.AddRange(order.OrderProducts);
            }

            var result = orders.Select(x => x.OrderProducts);
            
            return _mapper.Map<IEnumerable<Domain.Models.OrderProduct>>(orderProducts);
        }
    }
}
