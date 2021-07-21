using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PR.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PR.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IReportService _service;

        public ReportController(IReportService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Get([FromQuery(Name = "startDate")] DateTime? startDate, [FromQuery(Name = "endDate")] DateTime? endDate)
        {
            return Ok(_service.Get(startDate, endDate));
        }
    }
}
