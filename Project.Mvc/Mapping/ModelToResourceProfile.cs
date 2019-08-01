using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Project.Service.Domain.Models;
using Project.Mvc.Resources;


namespace Project.Mvc.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<VehicleMake, VehicleMakeResource>();
            CreateMap<VehicleModel, VehicleModelResource>();
        }
    }
}
