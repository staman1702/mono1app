using Project.Service0.Common;
using Project.Service0.Domain.Models;
using Project.Service0.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Service0.Domain.Repositories
{
    public interface IVehicleModelRepository
    {
        Task<PaginatedList<VehicleModel>> ListMakeAsync(PagingModel pagingModel, SortingModel sortingModel, FilteringModel filteringModel);
        Task AddAsync(VehicleModel vehicleModel);
        Task<VehicleModel> FindByIdAsync(Guid id);
        void Update(VehicleModel vehicleModel);
        void Remove(VehicleModel vehicleModel);
    }
}
