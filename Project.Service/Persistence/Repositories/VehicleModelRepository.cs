using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Project.Service.Models;
using Project.Service.Repositories;
using Project.Service.Persistence.Contexts;

namespace Project.Service.Persistence.Repositories
{
    public class VehicleModelRepository : BaseRepository, IVehicleModelRepository
    {
        public VehicleModelRepository(AppDbContext context) : base(context)
        {

        }

        public async Task<IEnumerable<VehicleModel>> ListAsync()
        {
            return await _context.VehicleModels.Include(p=>p.VehicleMake).ToListAsync();
        }

        public async Task AddAsync(VehicleModel vehicleModel)
        {
            await _context.VehicleModels.AddAsync(vehicleModel);
        }

        public async Task<VehicleModel> FindByIdAsync(int id)
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
