using PR.Domain.DTO;
using PR.Domain.Models;
using PR.Domain.Repositories;
using PR.Domain.Services;
using System;
using System.Linq;

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
            var order = new Order
            {
                ClientName = request.ClientName,
                OrderProducts = request.OrderProducts.Select(op => new OrderProduct()
                {
                    ProductName = op.ProductName,
                    Quantity = op.Quantity,
                    UnitPrice = op.UnitPrice
                }).ToList()
            };
            _repo.Create(order);
        }
    }
}
