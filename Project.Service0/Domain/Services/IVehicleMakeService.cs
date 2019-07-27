using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project.Service0.Common;
using Project.Service0.Domain.Models;
using Project.Service0.Domain.Services.Communication;


namespace Project.Service0.Domain.Services
{
    public interface IVehicleMakeService
    {
        Task<IEnumerable<VehicleMake>> ListAllAsync();
        Task<VehicleMake> FindAsync(Guid id);
        Task<VehicleResponse<VehicleMake>> SaveAsync(VehicleMake vehicleMake);
        Task<VehicleResponse<VehicleMake>> UpdateAsync(Guid id, VehicleMake vehicleMake);
        Task<VehicleResponse<VehicleMake>> DeleteAsync(Guid id);

    }
}
