using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project.Service.Common;
using Project.Service.Domain.Models;
using Project.Service.Domain.Services.Communication;
using Project.Service.Paging;

namespace Project.Service.Domain.Services
{
    public interface IVehicleMakeService
    {
        Task<PaginatedList<VehicleMake>> ListAllAsync(PagingModel pagingModel, SortingModel sortingModel, FilteringModel filteringModel);
        Task<VehicleResponse<VehicleMake>> SaveAsync(VehicleMake vehicleMake);
        Task<VehicleResponse<VehicleMake>> UpdateAsync(Guid id, VehicleMake vehicleMake);
        Task<VehicleResponse<VehicleMake>> DeleteAsync(Guid id);

    }
}
