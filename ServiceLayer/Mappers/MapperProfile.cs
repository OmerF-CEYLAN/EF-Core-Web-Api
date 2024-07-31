using AutoMapper;
using DataLayer.Entities;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ServiceLayer.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserResponseModel, User>().ReverseMap();

            CreateMap<UserRequestModel, User>().ReverseMap();
        }

    }
}