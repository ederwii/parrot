using PR.Domain.DTO;
using PR.Domain.Models;
using PR.Domain.Repositories;
using PR.Domain.Services;
using System;
using System.Collections.Generic;
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

        /// <summary>
        /// Create an Order from a CreateOrderRequest
        /// </summary>
        /// <param name="request"></param>
        /// <param name="userId">User who's creating the order</param>
        public void Create(CreateOrderRequest request, string userId)
        {
            if (!request.OrderProducts.Any())
                throw new ArgumentException("Can't create an order with no products");
            CreateProducts(request);

            var order = GetOrderFromRequest(request, userId);

            _repo.Create(order);
        }

        /// <summary>
        /// Iterate over order products and create products if needed
        /// </summary>
        /// <param name="request"></param>
        private void CreateProducts(CreateOrderRequest request)
        {
            var products = request.OrderProducts.Select(op => op.ProductName).Distinct();
            foreach (var product in products)
            {
                if(!_productRepo.Any(product))
                    _productRepo.Create(product);

            }
        }

        /// <summary>
        /// Get order total by looping through order products
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        private static decimal CalculateTotal(CreateOrderRequest request) => request.OrderProducts.Select(op => op.Quantity * op.UnitPrice).Sum();

        /// <summary>
        /// Create DTO model based upon request
        /// </summary>
        /// <param name="request"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        private static Order GetOrderFromRequest(CreateOrderRequest request, string userId)
        {
            var totalPrice = CalculateTotal(request);
            return new Order
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
        }

    }
}
