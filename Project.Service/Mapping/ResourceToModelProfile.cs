using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project.Service.Resources;
using Project.Service.Models;
using AutoMapper;


namespace Project.Service.Mapping
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
