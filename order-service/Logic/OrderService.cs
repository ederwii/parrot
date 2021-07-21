using PR.Domain.DTO;
using PR.Domain.Models;
using PR.Domain.Repositories;
using PR.Domain.Services;
using System;

namespace PR.Logic
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _repo;

        public OrderService(IOrderRepository repo)
        {
            _repo = repo;
        }

        public void Create(CreateOrderRequest request)
        {
            var order = new Order();
            _repo.Create(order);
        }
    }
}
