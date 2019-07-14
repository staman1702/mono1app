using Project.Service.Common;
using Project.Service.Domain.Models;
using Project.Service.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Service.Domain.Repositories
{
    public interface IVehicleModelRepository
    {
        Task<PaginatedList<VehicleModel>> ListMakeAsync(PagingModel pagingModel, SortingModel sortingModel, FilteringModel filteringModel);
        Task AddAsync(VehicleModel vehicleModel);
        Task<VehicleModel> FindByIdAsync(Guid id);
        void Update(VehicleModel vehicleModel);
        void Remove(VehicleModel vehicleModel);
        Task<IEnumerable<VehicleModel>> ListAsync();
    }
}
