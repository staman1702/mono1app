using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project.Service.Common;
using Project.Service.Domain.Models;
using Project.Service.Domain.Repositories;
using Project.Service.Domain.Services;
using Project.Service.Domain.Services.Communication;
using Project.Service.Paging;

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

        public async Task<PaginatedList<VehicleMake>> ListAllAsync(PagingModel pagingModel, SortingModel sortingModel, FilteringModel filteringModel)
        {
            return await _vehicleMakeRepository.ListMakeAsync(pagingModel, sortingModel, filteringModel);
        }

        public async Task<VehicleMakeResponse> SaveAsync(VehicleMake vehicleMake)
        {
            try
            {
                await _vehicleMakeRepository.AddAsync(vehicleMake);
                await _unitOfWork.CompleteAsync();

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
                await _unitOfWork.CompleteAsync();

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
                await _unitOfWork.CompleteAsync();

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
