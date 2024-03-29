﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project.Service.Domain.Models;
using Project.Service.Domain.Repositories;
using Project.Service.Domain.Services;
using Project.Service.Domain.Services.Communication;


namespace Project.Service.Services
{
    public class VehicleMakeService : IVehicleMakeService
    {
        private readonly IVehicleMakeRepository _vehicleMakeRepository;
        private readonly IUnitOfWork _unitOfWork;

        public VehicleMakeService(IVehicleMakeRepository vehicleMakeRepository, IUnitOfWork unitOfWork)
        {
            _vehicleMakeRepository = vehicleMakeRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<VehicleMake>> ListAllAsync()
        {
            return await _vehicleMakeRepository.ListMakeAsync();
        }

        public async Task<VehicleMake> FindMakeAsync(Guid id)
        {
            return await _vehicleMakeRepository.FindMakeByIdAsync(id);
            
        }

        public async Task<VehicleResponse<VehicleMake>> SaveAsync(VehicleMake vehicleMake)
        {
            try
            {
                await _vehicleMakeRepository.AddMakeAsync(vehicleMake);
                await _unitOfWork.CompleteAsync();

                return new VehicleResponse<VehicleMake>(vehicleMake);
            }
            catch (Exception ex)
            {
                return new VehicleResponse<VehicleMake>($"An error occurred when saving the vehicleMake: {ex.Message}");
            }
        }

        public async Task<VehicleResponse<VehicleMake>> UpdateAsync(Guid id, VehicleMake vehicleMake)
        {
            var existingVehicleMake = await _vehicleMakeRepository.FindMakeByIdAsync(id);

            if (existingVehicleMake == null)
                return new VehicleResponse<VehicleMake>("VehicleMake not found.");

            existingVehicleMake.Name = vehicleMake.Name;
            existingVehicleMake.Abrv = vehicleMake.Abrv;

            try
            {
                await _vehicleMakeRepository.UpdateMakeAsync(existingVehicleMake);
                await _unitOfWork.CompleteAsync();

                return new VehicleResponse<VehicleMake>(existingVehicleMake);
            }
            catch (Exception ex)
            {
                return new VehicleResponse<VehicleMake>($"An error occurred when updating the vehicleMake: {ex.Message}");
            }
        }

        public async Task<VehicleResponse<VehicleMake>> DeleteAsync(Guid id)
        {
            var existingVehicleMake = await _vehicleMakeRepository.FindMakeByIdAsync(id);

            if (existingVehicleMake == null)
                return new VehicleResponse<VehicleMake>("VehicleMake not found.");

            try
            {
                await _vehicleMakeRepository.DeleteMakeAsync(existingVehicleMake);
                await _unitOfWork.CompleteAsync();

                return new VehicleResponse<VehicleMake>(existingVehicleMake);
            }
            catch (Exception ex)
            {
                return new VehicleResponse<VehicleMake>($"An error occurred when deleting the vehicleMake: {ex.Message}");
            }
        }
    }
}
