using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project.Service.Domain.Repositories;
using Project.Service.Domain.Models;
using Project.Service.Domain.Services.Communication;
using Project.Service.Domain.Services;

namespace Project.Service.Services
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

        public async Task<IEnumerable<VehicleModel>> ListModelAsync()
        {
            return await _vehicleModelRepository.ListAsync();
        }

        public async Task<VehicleModelResponse> SaveModelAsync(VehicleModel vehicleModel)
        {
            try
            {
                await _vehicleModelRepository.AddAsync(vehicleModel);
                await _unitOfWork.CompleteAsync();


                return new VehicleModelResponse(vehicleModel);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new VehicleModelResponse($"An error occurred when saving the vehicleModel: {ex.Message}");
            }
        }

        public async Task<VehicleModelResponse> UpdateModelAsync(Guid id, VehicleModel vehicleModel)
        {
            var existingVehicleModel = await _vehicleModelRepository.FindByIdAsync(id);

            if (existingVehicleModel == null)
                return new VehicleModelResponse("VehicleModel not found.");

            existingVehicleModel.Name = vehicleModel.Name;
            existingVehicleModel.Abrv = vehicleModel.Abrv;
            existingVehicleModel.VehicleMakeId = vehicleModel.VehicleMakeId;

            try
            {
                _vehicleModelRepository.Update(existingVehicleModel);
                await _unitOfWork.CompleteAsync();



                return new VehicleModelResponse(existingVehicleModel);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new VehicleModelResponse($"An error occurred when updating the vehicleModel: {ex.Message}");
            }
        }

        public async Task<VehicleModelResponse> DeleteModelAsync(Guid id)
        {
            var existingVehicleModel = await _vehicleModelRepository.FindByIdAsync(id);

            if (existingVehicleModel == null)
                return new VehicleModelResponse("VehicleModel not found.");

            try
            {
                _vehicleModelRepository.Remove(existingVehicleModel);
                await _unitOfWork.CompleteAsync();


                return new VehicleModelResponse(existingVehicleModel);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new VehicleModelResponse($"An error occurred when deleting the vehicleMake: {ex.Message}");
            }
        }

    }
}
