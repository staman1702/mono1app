using Project.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Service.Repositories
{
    public interface IVehicleModelRepository
    {
        Task<IEnumerable<VehicleModel>> ListAsync();
        Task AddAsync(VehicleModel vehicleModel);
        Task<VehicleModel> FindByIdAsync(Guid id);
        void Update(VehicleModel vehicleModel);
        void Remove(VehicleModel vehicleModel);
    }
}
