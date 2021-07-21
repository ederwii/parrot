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
        private readonly IProductRepository _productRepo;

        public OrderService(IOrderRepository repo, IProductRepository productRepo)
        {
            _repo = repo;
            _productRepo = productRepo;
        }

        public void Create(CreateOrderRequest request, string userId)
        {
            var products = request.OrderProducts.Select(op => op.ProductName).Distinct();
            foreach (var product in products) 
            {
                _productRepo.Create(product);

            }

            var totalPrice = request.OrderProducts.Select(op => op.Quantity * op.UnitPrice).Sum();
            var order = new Order
            {
                ClientName = request.ClientName,
                OrderProducts = request.OrderProducts.Select(op => new OrderProduct()
                {
                    ProductName = op.ProductName,
                    Quantity = op.Quantity,
                    UnitPrice = op.UnitPrice
                }).ToList(),
                TotalPrice = totalPrice,
                UserId = userId
            };
            _repo.Create(order);
        }
    }
}
