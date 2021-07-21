using AutoMapper;
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
    }
}
