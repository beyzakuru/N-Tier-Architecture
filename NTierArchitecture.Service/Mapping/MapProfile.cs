using AutoMapper;
using NTierArchitecture.Core.DTOs;
using NTierArchitecture.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierArchitecture.Service.Mapping
{
    public class MapProfile: Profile
    {
        public MapProfile() 
        { 
            // Entity'den Dto'ya çevirme
            CreateMap<Journey, JourneyDto>().ReverseMap();
            CreateMap<Passenger, PassengerDto>().ReverseMap();
            CreateMap<Passport, PassportDto>().ReverseMap();

            // Dto'dan entity'e çevirme
            CreateMap<JourneyDto, Journey>();
            CreateMap<PassengerDto, Passenger>();
            CreateMap<PassportDto, Passport>();
        }
    }
}
