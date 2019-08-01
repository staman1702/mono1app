using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Service.Domain.Models
{
    public class VehicleModel : Vehicle
    {  
        public Guid VehicleMakeId { get; set; }
        public VehicleMake VehicleMake { get; set; }
    }
}
