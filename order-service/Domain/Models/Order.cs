using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR.Domain.Models
{
    public class Order
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public string ClientName { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
