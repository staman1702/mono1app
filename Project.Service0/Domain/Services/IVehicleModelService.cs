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
    public interface IVehicleModelService
    {
        Task<PaginatedList<VehicleModel>> ListAllAsync(PagingModel pagingModel, SortingModel sortingModel, FilteringModel filteringModel);
        Task<VehicleResponse<VehicleModel>> SaveModelAsync(VehicleModel vehicleModel);
        Task<VehicleResponse<VehicleModel>> UpdateModelAsync(Guid id, VehicleModel vehicleModel);
        Task<VehicleResponse<VehicleModel>> DeleteModelAsync(Guid id);

    }
}
