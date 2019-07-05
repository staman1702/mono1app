using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Service.Domain.Models
{
    public interface IVehicleMake
    {        
        Guid Id { get; set; }
        string Name { get; set; }
        string Abrv { get; set; }
        ICollection<IVehicleModel> VehicleModel { get; set; }
    }
}
}
