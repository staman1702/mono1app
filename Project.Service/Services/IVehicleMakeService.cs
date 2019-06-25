using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project.Service.Models;
using Project.Service.Services.Communication;

namespace Project.Service.Services
{
    public interface IVehicleMakeService
    {
        Task<IEnumerable<VehicleMake>> ListAsync();
        Task<VehicleMakeResponse> SaveAsync(VehicleMake vehicleMake);
        Task<VehicleMakeResponse> UpdateAsync(int id, VehicleMake vehicleMake);
        Task<VehicleMakeResponse> DeleteAsync(int id);
    }
}
