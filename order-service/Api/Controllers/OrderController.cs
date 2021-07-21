﻿using System;
using System.Linq;
using PR.Api.Helpers;
using Microsoft.AspNetCore.Mvc;
using PR.Domain.DTO;
using PR.Domain.Services;
using PR.Domain.Models;

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
            var user = (User)HttpContext.Items["User"];
            _service.Create(request, user.Id);
            return Ok("Ok");
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Pong");
        }
    }
}
