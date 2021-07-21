using System;
using System.Linq;
using PR.Api.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace PR.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class PingController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Pong");
        }
    }
}
