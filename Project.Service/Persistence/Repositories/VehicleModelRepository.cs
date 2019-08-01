using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Project.Service.Domain.Models;
using Project.Service.Domain.Repositories;
using Project.Service.Persistence.Contexts;

namespace Project.Service.Persistence.Repositories
{
    public class VehicleModelRepository : BaseRepository, IVehicleModelRepository
    {
        public VehicleModelRepository(AppDbContext context) : base(context)
        {

        }

        public async Task<IEnumerable<VehicleModel>> ListModelAsync()
        {
            return await _context.VehicleModels.Include(p => p.VehicleMake).ToListAsync();
        }

        public async Task AddAsync(VehicleModel vehicleModel)
        {
            await _context.VehicleModels.AddAsync(vehicleModel);
        }

        public async Task<VehicleModel> FindByIdAsync(Guid id)
        {
            return await _context.VehicleModels.FindAsync(id);
        }

        public void Update(VehicleModel vehicleModel)
        {
            _context.VehicleModels.Update(vehicleModel);
        }

        public void Remove(VehicleModel vehicleModel)
        {
            _context.VehicleModels.Remove(vehicleModel);
        }

    }
}
