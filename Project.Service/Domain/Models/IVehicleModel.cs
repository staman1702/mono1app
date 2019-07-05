using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Service.Domain.Models
{
    public interface IVehicleModel
    {
        Guid Id { get; set; }
        string Name { get; set; }
        string Abrv { get; set; }

        Guid VehicleMakeId { get; set; }
        IVehicleMake VehicleMake { get; set; }
    }
}
