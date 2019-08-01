using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Service.Domain.Models
{
    public class VehicleMake : Vehicle
    {        
        public IList<VehicleModel> VehicleModels { get; set; } = new List<VehicleModel>();
    }
}
