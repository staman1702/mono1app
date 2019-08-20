using System;
using System.Collections.Generic;
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

        public async Task<IEnumerable<VehicleModel>> ListAllAsync()
        {
            return await _vehicleModelRepository.ListModelAsync();
        }

        public async Task<VehicleModel> FindModelAsync(Guid id)
        {
            return await _vehicleModelRepository.FindModelByIdAsync(id);

        }

        public async Task<VehicleResponse<VehicleModel>> SaveAsync(VehicleModel vehicleModel)
        {
            try
            {
                await _vehicleModelRepository.AddModelAsync(vehicleModel);
                await _unitOfWork.CompleteAsync();


                return new VehicleResponse<VehicleModel>(vehicleModel);
            }
            catch (Exception ex)
            {
                return new VehicleResponse<VehicleModel>($"An error occurred when saving the vehicleModel: {ex.Message}");
            }
        }

        public async Task<VehicleResponse<VehicleModel>> UpdateAsync(Guid id, VehicleModel vehicleModel)
        {
            var existingVehicleModel = await _vehicleModelRepository.FindModelByIdAsync(id);

            if (existingVehicleModel == null)
                return new VehicleResponse<VehicleModel>("VehicleModel not found.");

            existingVehicleModel.Name = vehicleModel.Name;
            existingVehicleModel.Abrv = vehicleModel.Abrv;
            existingVehicleModel.VehicleMakeId = vehicleModel.VehicleMakeId;

            try
            {
                await _vehicleModelRepository.UpdateModelAsync(existingVehicleModel);
                await _unitOfWork.CompleteAsync();



                return new VehicleResponse<VehicleModel>(existingVehicleModel);
            }
            catch (Exception ex)
            {
                return new VehicleResponse<VehicleModel>($"An error occurred when updating the vehicleModel: {ex.Message}");
            }
        }

        public async Task<VehicleResponse<VehicleModel>> DeleteAsync(Guid id)
        {
            var existingVehicleModel = await _vehicleModelRepository.FindModelByIdAsync(id);

            if (existingVehicleModel == null)
                return new VehicleResponse<VehicleModel>("VehicleModel not found.");

            try
            {
                await _vehicleModelRepository.RemoveModelAsync(existingVehicleModel);
                await _unitOfWork.CompleteAsync();


                return new VehicleResponse<VehicleModel>(existingVehicleModel);
            }
            catch (Exception ex)
            {
                return new VehicleResponse<VehicleModel>($"An error occurred when deleting the vehicleMake: {ex.Message}");
            }
        }
    }
}
