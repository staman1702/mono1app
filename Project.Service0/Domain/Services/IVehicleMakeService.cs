using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project.Service0.Common;
using Project.Service0.Domain.Models;
using Project.Service0.Domain.Services.Communication;
using Project.Service0.Paging;

namespace Project.Service0.Domain.Services
{
    public interface IVehicleMakeService
    {
        Task<PaginatedList<VehicleMake>> ListAllAsync(PagingModel pagingModel, SortingModel sortingModel, FilteringModel filteringModel);
        Task<VehicleResponse<VehicleMake>> SaveAsync(VehicleMake vehicleMake);
        Task<VehicleResponse<VehicleMake>> UpdateAsync(Guid id, VehicleMake vehicleMake);
        Task<VehicleResponse<VehicleMake>> DeleteAsync(Guid id);

    }
}
