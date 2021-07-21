using PR.Domain.Models;
using PR.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly OrderDbContext _context;

        public ProductRepository(OrderDbContext context)
        {
            _context = context;
        }

        public bool Any(string productName) => _context.Products.Any(p => p.Name == productName);

        public void Create(string productName)
        {
            _context.Products.Add(new Models.Product()
            {
                Name = productName
            });
            _context.SaveChanges();
        }
    }
}
