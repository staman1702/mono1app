using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Project.Service.Common;
using Project.Service.Domain.Models;
using Project.Service.Domain.Repositories;
using Project.Service.Paging;
using Project.Service.Persistence.Contexts;

namespace Project.Service.Persistence.Repositories
{
    public class VehicleMakeRepository :BaseRepository, IVehicleMakeRepository
    {
        public VehicleMakeRepository(AppDbContext context) : base(context)
        {

        }


        public async Task<PaginatedList<VehicleMake>> ListMakeAsync(PagingModel pagingModel, SortingModel sortingModel, FilteringModel filteringModel)
        {
            var vehicleMakes = from vehicle in _context.VehicleMakes select vehicle;
            if (filteringModel.Filter != null)
            {
                vehicleMakes = vehicleMakes.Where(vehicleModel => vehicleModel.Name.Contains(filteringModel.Filter)
                                                                 || vehicleModel.Abrv.Contains(filteringModel.Filter));
            }


            if (string.IsNullOrEmpty(sortingModel.SortBy))
            {
                vehicleMakes = vehicleMakes.OrderBy(vehicleModel => vehicleModel.Id);
            }
            else if (sortingModel.SortBy.Equals("Name", StringComparison.OrdinalIgnoreCase))
            {
                vehicleMakes = vehicleMakes.OrderBy(vehicleModel => vehicleModel.Name);
            }
            else if (sortingModel.SortBy.Equals("NameDesc", StringComparison.OrdinalIgnoreCase))
            {
                vehicleMakes = vehicleMakes.OrderByDescending(vehicleModel => vehicleModel.Name);
            }
            else if (sortingModel.SortBy.Equals("Abrv", StringComparison.OrdinalIgnoreCase))
            {
                vehicleMakes = vehicleMakes.OrderBy(vehicleModel => vehicleModel.Abrv);
            }
            else if (sortingModel.SortBy.Equals("AbrvDesc", StringComparison.OrdinalIgnoreCase))
            {
                vehicleMakes = vehicleMakes.OrderByDescending(vehicleModel => vehicleModel.Abrv);
            }



            return await PaginatedList<VehicleMake>.CreateAsync
                (vehicleMakes, pagingModel.CurrentPage ?? 1, pagingModel.TotalPages ?? _context.VehicleModels.Count());

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

        public async Task<IEnumerable<VehicleMake>> ListAsync()
        {
            return await _context.VehicleMakes.ToListAsync();
        }
    }
}
