using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Project.Service0.Domain.Models;
using Project.Service0.Domain.Repositories;
using Project.Service0.Persistence.Contexts;

namespace Project.Service0.Persistence.Repositories
{
    public class VehicleMakeRepository : BaseRepository, IVehicleMakeRepository
    {
        public VehicleMakeRepository(AppDbContext context) : base(context)
        {

        }

        public async Task<IEnumerable<VehicleMake>> ListMakeAsync()
        {
            return await _context.VehicleMakes.ToListAsync();
        }   

        public async Task AddAsync(VehicleMake vehicleMake)
        {
            await _context.VehicleMakes.AddAsync(vehicleMake);
        }

        public async Task<VehicleMake> FindByIdAsync(Guid id)
        {
            return await _context.VehicleMakes.FindAsync(id);
        }

        public void Update(VehicleMake vehicleMake)
        {
            _context.VehicleMakes.Update(vehicleMake);
        }

        public void Remove(VehicleMake vehicleMake)
        {
            _context.VehicleMakes.Remove(vehicleMake);
        }

    }
}
