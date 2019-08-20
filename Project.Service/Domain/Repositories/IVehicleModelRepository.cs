using Project.Service.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Project.Service.Domain.Repositories
{
    public interface IVehicleModelRepository
    {
        Task<IEnumerable<VehicleModel>> ListModelAsync();
        Task AddModelAsync(VehicleModel vehicleModel);
        Task<VehicleModel> FindModelByIdAsync(Guid id);
        Task UpdateModelAsync(VehicleModel vehicleModel);
        Task RemoveModelAsync(VehicleModel vehicleModel);
    }
}
