using PR.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR.Domain.Repositories
{
    public interface IProductRepository
    {
        public void Create(string productName);

        public bool Any(string productName);
    }
}
