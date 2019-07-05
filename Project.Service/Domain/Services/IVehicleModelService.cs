using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project.Service.Domain.Models;
using Project.Service.Domain.Services.Communication;

namespace Project.Service.Domain.Services
{
    public interface IVehicleModelService
    {
        Task<IEnumerable<VehicleModel>> ListModelAsync();
        Task<VehicleModelResponse> SaveModelAsync(VehicleModel vehicleModel);
        Task<VehicleModelResponse> UpdateModelAsync(Guid id, VehicleModel vehicleModel);
        Task<VehicleModelResponse> DeleteModelAsync(Guid id);
    }
}
