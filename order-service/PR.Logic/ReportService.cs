using PR.Domain.DTO;
using PR.Domain.Repositories;
using PR.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR.Logic
{
    public class ReportService : IReportService
    {
        private readonly IOrderRepository _repo;

        public ReportService(IOrderRepository repo)
        {
            _repo = repo;
        }
        public IEnumerable<ReportLine> Get(DateTime? startDate, DateTime? endDate)
        {
            var orderProductsByName = _repo.GetOrderProducts(startDate, endDate).GroupBy(x => x.ProductName, StringComparer.OrdinalIgnoreCase);
            
            var result = new List<ReportLine>();

            result = orderProductsByName.Select(group => new ReportLine()
            {
                ProductName = group.Key,
                TotalAmount = group.Select(op => op.Quantity).Sum(),
                TotalPrice = group.Select(op => op.Quantity * op.UnitPrice).Sum()

            }).ToList();

            return result;
        }
    }
}
