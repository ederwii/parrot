using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR.Domain.DTO
{
    public class ReportLine
    {
        public string ProductName { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
