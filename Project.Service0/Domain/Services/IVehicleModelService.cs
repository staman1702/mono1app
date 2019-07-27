﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Project.Service0.Domain.Models;
using Project.Service0.Domain.Services.Communication;


namespace Project.Service0.Domain.Services
{
    public interface IVehicleModelService
    {
        Task<IEnumerable<VehicleModel>> ListAllAsync();
        Task<VehicleModel> FindModelAsync(Guid id);
        Task<VehicleResponse<VehicleModel>> SaveModelAsync(VehicleModel vehicleModel);
        Task<VehicleResponse<VehicleModel>> UpdateModelAsync(Guid id, VehicleModel vehicleModel);
        Task<VehicleResponse<VehicleModel>> DeleteModelAsync(Guid id);

    }
}
