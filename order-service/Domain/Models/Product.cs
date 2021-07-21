using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR.Domain.Models
{
    public class Product
    {
        public string Name { get; set; }
        public IList<OrderProduct> OrderProducts { get; set; }
    }
}
