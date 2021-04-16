using AutoMapper;
using Generic.Repo.API.Domain;
using Generic.Repo.API.Mapping.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Generic.Repo.API.Mapping
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserReadDto>();
            CreateMap<UserCreateDto, User>();

            CreateMap<Order, OrderReadDto>();
            CreateMap<OrderCreateDto, Order>();
        }
    }
}
