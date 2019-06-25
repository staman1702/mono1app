using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project.Service.Models;


namespace Project.Service.Repositories
{
    public interface IVehicleMakeRepository
    {
        Task<IEnumerable<VehicleMake>> ListAsync();
        Task AddAsync(VehicleMake vehicleMake);
        Task<VehicleMake> FindByIdAsync(int id);
        void Update(VehicleMake vehicleMake);
        void Remove(VehicleMake vehicleMake);
    }
}
