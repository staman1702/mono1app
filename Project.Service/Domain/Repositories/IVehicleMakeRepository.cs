using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project.Service.Domain.Models;


namespace Project.Service.Domain.Repositories
{
    public interface IVehicleMakeRepository
    {
        Task<IEnumerable<VehicleMake>> ListMakeAsync();
        Task AddMakeAsync(VehicleMake vehicleMake);
        Task<VehicleMake> FindMakeByIdAsync(Guid id);
        Task UpdateMakeAsync(VehicleMake vehicleMake);
        Task DeleteMakeAsync(VehicleMake vehicleMake);
    }
}
