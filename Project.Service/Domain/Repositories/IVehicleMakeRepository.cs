using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project.Service.Common;
using Project.Service.Domain.Models;
using Project.Service.Paging;

namespace Project.Service.Domain.Repositories
{
    public interface IVehicleMakeRepository
    {
        Task<PaginatedList<VehicleMake>> ListMakeAsync(PagingModel pagingModel, SortingModel sortingModel, FilteringModel filteringModel);
        Task AddAsync(VehicleMake vehicleMake);
        Task<VehicleMake> FindByIdAsync(Guid id);
        void Update(VehicleMake vehicleMake);
        void Remove(VehicleMake vehicleMake);
    }
}
