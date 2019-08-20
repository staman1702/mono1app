using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Project.Service.Domain.Models;
using Project.Service.Domain.Services.Communication;


namespace Project.Service.Domain.Services
{
    public interface IVehicleModelService
    {
        Task<IEnumerable<VehicleModel>> ListAllAsync();
        Task<VehicleModel> FindModelAsync(Guid id);
        Task<VehicleResponse<VehicleModel>> SaveAsync(VehicleModel vehicleModel);
        Task<VehicleResponse<VehicleModel>> UpdateAsync(Guid id, VehicleModel vehicleModel);
        Task<VehicleResponse<VehicleModel>> DeleteAsync(Guid id);

    }
}
