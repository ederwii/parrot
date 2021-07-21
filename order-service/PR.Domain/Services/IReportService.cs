using PR.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR.Domain.Services
{
    public interface IReportService
    {
        public IEnumerable<ReportLine> Get(DateTime? startDate, DateTime? endDate);
    }
}
