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
    public interface IVehicleModelService
    {
        Task<PaginatedList<VehicleModel>> ListAllAsync(PagingModel pagingModel, SortingModel sortingModel, FilteringModel filteringModel);
        Task<VehicleResponse<VehicleModel>> SaveModelAsync(VehicleModel vehicleModel);
        Task<VehicleResponse<VehicleModel>> UpdateModelAsync(Guid id, VehicleModel vehicleModel);
        Task<VehicleResponse<VehicleModel>> DeleteModelAsync(Guid id);

    }
}
