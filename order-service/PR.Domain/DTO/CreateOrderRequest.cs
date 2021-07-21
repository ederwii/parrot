using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR.Domain.DTO
{
    public class CreateOrderRequest
    {
        public string ClientName { get; set; }
        public IEnumerable<Product> OrderProducts { get; set; }
    }
}
