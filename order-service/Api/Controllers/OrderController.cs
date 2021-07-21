using System;
using System.Linq;
using PR.Api.Helpers;
using Microsoft.AspNetCore.Mvc;
using PR.Domain.DTO;
using PR.Domain.Services;

namespace PR.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _service;
        public OrderController(IOrderService service)
        {
            _service = service;
        }
        [HttpPost]
        public IActionResult Post(CreateOrderRequest request)
        {
            _service.Create(request);
            return Ok("Ok");
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Pong");
        }
    }
}
