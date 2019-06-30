using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project.Service.Models;
using Project.Service.Services.Communication;

namespace Project.Service.Services
{
    public interface IVehicleModelService
    {
        Task<IEnumerable<VehicleModel>> ListModelAsync();
        Task<VehicleModelResponse> SaveModelAsync(VehicleModel vehicleModel);
        Task<VehicleModelResponse> UpdateModelAsync(Guid id, VehicleModel vehicleModel);
        Task<VehicleModelResponse> DeleteModelAsync(Guid id);
    }
}
