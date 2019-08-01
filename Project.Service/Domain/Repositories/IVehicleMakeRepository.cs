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
        Task AddAsync(VehicleMake vehicleMake);
        Task<VehicleMake> FindByIdAsync(Guid id);
        void Update(VehicleMake vehicleMake);
        void Remove(VehicleMake vehicleMake);
    }
}
