using Moq;
using NUnit.Framework;
using PR.Domain.DTO;
using PR.Domain.Repositories;
using PR.Domain.Services;
using PR.Logic;
using System;
using System.Collections.Generic;

namespace Tests
{
    public class Tests
    {
        private IOrderService service;

        [OneTimeSetUp]
        public void Setup()
        {
            var orderRepo = new Mock<IOrderRepository>();
            var productRepo = new Mock<IProductRepository>();
            service = new OrderService(orderRepo.Object, productRepo.Object);
        }

        [Test]
        public void CreateOrder()
        {
            var request = new CreateOrderRequest()
            {
                ClientName = "test",
                OrderProducts = new List<Product>()
                {
                    new Product()
                    {
                        ProductName = "Test product",
                        Quantity = 1,
                        UnitPrice = 10
                    }
                }
            };

            service.Create(request, "user");
            Assert.Pass();
        }

        [Test]
        public void ThrowExceptionIfNoProductsOnOrder()
        {
            var request = new CreateOrderRequest()
            {
                ClientName = "test",
                OrderProducts = new List<Product>()
                {

                }
            };

            Assert.Throws<ArgumentException>(() => service.Create(request, "user"));
        }
    }
}