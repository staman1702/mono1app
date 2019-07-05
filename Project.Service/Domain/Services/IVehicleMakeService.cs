using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project.Service.Domain.Models;
using Project.Service.Domain.Services.Communication;

namespace Project.Service.Domain.Services
{
    public interface IVehicleMakeService
    {
        Task<IEnumerable<VehicleMake>> ListAsync();
        Task<VehicleMakeResponse> SaveAsync(VehicleMake vehicleMake);
        Task<VehicleMakeResponse> UpdateAsync(Guid id, VehicleMake vehicleMake);
        Task<VehicleMakeResponse> DeleteAsync(Guid id);
    }
}
