using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project.Mvc0.Resources;
using Project.Service0.Domain.Models;
using AutoMapper;


namespace Project.Mvc0.Mapping
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
