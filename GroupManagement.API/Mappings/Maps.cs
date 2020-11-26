using AutoMapper;
using GroupManagement.DTOs;
using GroupManagement.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroupManagement.API.Mappings
{
    public class Maps : Profile
    {
        public Maps()
        {
            CreateMap<City, CityDTO>().ReverseMap();
            CreateMap<City, CityCreateDTO>().ReverseMap();
            CreateMap<Country, CountryDTO>().ReverseMap();
            CreateMap<IdentityUser, UserLoggedInDTO>();
        }
    }
}
