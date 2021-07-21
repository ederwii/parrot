
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PR.Api.Helpers
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<PR.Data.Models.Order, PR.Domain.Models.Order>().ReverseMap();
            CreateMap<PR.Data.Models.OrderProduct, PR.Domain.Models.OrderProduct>().ReverseMap();
            CreateMap<PR.Data.Models.Product, PR.Domain.Models.Product>().ReverseMap();
        }
    }
}

