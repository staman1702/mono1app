using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Project.Service.Domain.Models;
using Project.Service.Domain.Services.Communication;


namespace Project.Service.Domain.Services
{
    public interface IVehicleMakeService
    {
        Task<IEnumerable<VehicleMake>> ListAllAsync();
        Task<VehicleMake> FindMakeAsync(Guid id);
        Task<VehicleResponse<VehicleMake>> SaveAsync(VehicleMake vehicleMake);
        Task<VehicleResponse<VehicleMake>> UpdateAsync(Guid id, VehicleMake vehicleMake);
        Task<VehicleResponse<VehicleMake>> DeleteAsync(Guid id);

    }
}
