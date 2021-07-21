using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR.Data.Models
{
    public class Product
    {
        [Key]
        public string Name { get; set; }
        public IList<OrderProduct> OrderProducts { get; set; }
    }
}
