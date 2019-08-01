using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project.Mvc.Resources;
using Project.Service.Domain.Models;
using AutoMapper;


namespace Project.Mvc.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<SaveVehicleMakeResource, VehicleMake>();
            CreateMap<SaveVehicleModelResource, VehicleModel>();
        }
    }
}
