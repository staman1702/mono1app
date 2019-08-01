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
        Task AddAsync(VehicleModel vehicleModel);
        Task<VehicleModel> FindByIdAsync(Guid id);
        void Update(VehicleModel vehicleModel);
        void Remove(VehicleModel vehicleModel);
    }
}
