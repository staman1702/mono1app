using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project.Service.Models;
using Project.Service.Repositories;
using Project.Service.Services.Communication;

namespace Project.Service.Services
{
    public class VehicleMakeService : IVehicleMakeService
    {
        private readonly IVehicleMakeRepository _vehicleMakeRepository;

        public VehicleMakeService(IVehicleMakeRepository vehicleMakeRepository)
        {
            _vehicleMakeRepository = vehicleMakeRepository;           
        }

        public async Task<IEnumerable<VehicleMake>> ListAsync()
        {
            return await _vehicleMakeRepository.ListAsync();
        }

        public async Task<VehicleMakeResponse> SaveAsync(VehicleMake vehicleMake)
        {
            try
            {
                await _vehicleMakeRepository.AddAsync(vehicleMake);

                return new VehicleMakeResponse(vehicleMake);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new VehicleMakeResponse($"An error occurred when saving the vehicleMake: {ex.Message}");
            }
        }

        public async Task<VehicleMakeResponse> UpdateAsync(Guid id, VehicleMake vehicleMake)
        {
            var existingVehicleMake = await _vehicleMakeRepository.FindByIdAsync(id);

            if (existingVehicleMake == null)
                return new VehicleMakeResponse("VehicleMake not found.");

            existingVehicleMake.Name = vehicleMake.Name;
            existingVehicleMake.Abrv = vehicleMake.Abrv;

            try
            {
                _vehicleMakeRepository.Update(existingVehicleMake);

                return new VehicleMakeResponse(existingVehicleMake);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new VehicleMakeResponse($"An error occurred when updating the vehicleMake: {ex.Message}");
            }
        }

        public async Task<VehicleMakeResponse> DeleteAsync(Guid id)
        {
            var existingVehicleMake = await _vehicleMakeRepository.FindByIdAsync(id);

            if (existingVehicleMake == null)
                return new VehicleMakeResponse("VehicleMake not found.");

            try
            {
                _vehicleMakeRepository.Remove(existingVehicleMake);

                return new VehicleMakeResponse(existingVehicleMake);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new VehicleMakeResponse($"An error occurred when deleting the vehicleMake: {ex.Message}");
            }
        }

    }
}
