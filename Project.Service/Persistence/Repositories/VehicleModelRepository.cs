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
    public class VehicleModelRepository : BaseRepository, IVehicleModelRepository
    {
        public VehicleModelRepository(AppDbContext context) : base(context)
        {

        }

        public async Task<PaginatedList<VehicleModel>> ListMakeAsync(PagingModel pagingModel, SortingModel sortingModel, FilteringModel filteringModel)
        {
            var vehicleModels = from vehicle in _context.VehicleModels.Include(p => p.VehicleMake) select vehicle;
            if (filteringModel.Filter != null)
            {
                vehicleModels = vehicleModels.Where(vehicleModel => vehicleModel.Name.Contains(filteringModel.Filter)
                                                                 || vehicleModel.Abrv.Contains(filteringModel.Filter));
            }


            if (string.IsNullOrEmpty(sortingModel.SortBy))
            {
                vehicleModels = vehicleModels.OrderBy(vehicleModel => vehicleModel.Id);
            }
            else if (sortingModel.SortBy.Equals("Name", StringComparison.OrdinalIgnoreCase))
            {
                vehicleModels = vehicleModels.OrderBy(vehicleModel => vehicleModel.Name);
            }
            else if (sortingModel.SortBy.Equals("NameDesc", StringComparison.OrdinalIgnoreCase))
            {
                vehicleModels = vehicleModels.OrderByDescending(vehicleModel => vehicleModel.Name);
            }
            else if (sortingModel.SortBy.Equals("Abrv", StringComparison.OrdinalIgnoreCase))
            {
                vehicleModels = vehicleModels.OrderBy(vehicleModel => vehicleModel.Abrv);
            }
            else if (sortingModel.SortBy.Equals("AbrvDesc", StringComparison.OrdinalIgnoreCase))
            {
                vehicleModels = vehicleModels.OrderByDescending(vehicleModel => vehicleModel.Abrv);
            }
            else if (sortingModel.SortBy.Equals("VehicleMakeId", StringComparison.OrdinalIgnoreCase))
            {
                vehicleModels = vehicleModels.OrderBy(vehicleModel => vehicleModel.VehicleMakeId);
            }
            else if (sortingModel.SortBy.Equals("VehicleMakeIdDesc", StringComparison.OrdinalIgnoreCase))
            {
                vehicleModels = vehicleModels.OrderByDescending(vehicleModel => vehicleModel.VehicleMakeId);
            }


            return await PaginatedList<VehicleModel>.CreateAsync
                (vehicleModels, pagingModel.CurrentPage ?? 1, pagingModel.TotalPages ?? _context.VehicleModels.Count());

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

        public async Task<IEnumerable<VehicleModel>> ListAsync()
        {
            return await _context.VehicleModels.Include(p => p.VehicleMake).ToListAsync();
        }
    }
}
