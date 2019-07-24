using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project.Service0.Domain.Repositories;
using Project.Service0.Domain.Models;
using Project.Service0.Domain.Services.Communication;
using Project.Service0.Domain.Services;
using Project.Service0.Paging;
using Project.Service0.Common;

namespace Project.Service0.Services
{
    public class VehicleModelService : IVehicleModelService
    {
        private readonly IVehicleModelRepository _vehicleModelRepository;
        private readonly IUnitOfWork _unitOfWork;

        public VehicleModelService(IVehicleModelRepository vehicleModelRepository, IUnitOfWork unitOfWork)
        {
            _vehicleModelRepository = vehicleModelRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<PaginatedList<VehicleModel>> ListAllAsync(PagingModel pagingModel, SortingModel sortingModel, FilteringModel filteringModel)
        {
            return await _vehicleModelRepository.ListMakeAsync(pagingModel, sortingModel, filteringModel);
        }


        public async Task<VehicleResponse<VehicleModel>> SaveModelAsync(VehicleModel vehicleModel)
        {
            try
            {
                await _vehicleModelRepository.AddAsync(vehicleModel);
                await _unitOfWork.CompleteAsync();


                return new VehicleResponse<VehicleModel>(vehicleModel);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new VehicleResponse<VehicleModel>($"An error occurred when saving the vehicleModel: {ex.Message}");
            }
        }

        public async Task<VehicleResponse<VehicleModel>> UpdateModelAsync(Guid id, VehicleModel vehicleModel)
        {
            var existingVehicleModel = await _vehicleModelRepository.FindByIdAsync(id);

            if (existingVehicleModel == null)
                return new VehicleResponse<VehicleModel>("VehicleModel not found.");

            existingVehicleModel.Name = vehicleModel.Name;
            existingVehicleModel.Abrv = vehicleModel.Abrv;
            existingVehicleModel.VehicleMakeId = vehicleModel.VehicleMakeId;

            try
            {
                _vehicleModelRepository.Update(existingVehicleModel);
                await _unitOfWork.CompleteAsync();



                return new VehicleResponse<VehicleModel>(existingVehicleModel);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new VehicleResponse<VehicleModel>($"An error occurred when updating the vehicleModel: {ex.Message}");
            }
        }

        public async Task<VehicleResponse<VehicleModel>> DeleteModelAsync(Guid id)
        {
            var existingVehicleModel = await _vehicleModelRepository.FindByIdAsync(id);

            if (existingVehicleModel == null)
                return new VehicleResponse<VehicleModel>("VehicleModel not found.");

            try
            {
                _vehicleModelRepository.Remove(existingVehicleModel);
                await _unitOfWork.CompleteAsync();


                return new VehicleResponse<VehicleModel>(existingVehicleModel);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new VehicleResponse<VehicleModel>($"An error occurred when deleting the vehicleMake: {ex.Message}");
            }
        }
    }
}
