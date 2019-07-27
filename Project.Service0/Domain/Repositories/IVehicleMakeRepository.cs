using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project.Service0.Common;
using Project.Service0.Domain.Models;


namespace Project.Service0.Domain.Repositories
{
    public interface IVehicleMakeRepository
    {
        Task<IEnumerable<VehicleMake>> ListMakeAsync();
        Task AddAsync(VehicleMake vehicleMake);
        Task<VehicleMake> FindByIdAsync(Guid id);
        void Update(VehicleMake vehicleMake);
        void Remove(VehicleMake vehicleMake);
    }
}
