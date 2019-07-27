using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Project.Service0.Domain.Services;
using AutoMapper;
using Project.Mvc0.Resources;
using Project.Mvc0.Extensions;
using Project.Service0.Domain.Models;

namespace Project.Mvc0.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleModelAPIController : ControllerBase
    {

        private readonly IVehicleModelService _vehicleModelService;
        private readonly IMapper _mapper;

        public VehicleModelAPIController(IVehicleModelService vehicleModelService, IMapper mapper)
        {
            _vehicleModelService = vehicleModelService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<VehicleModelResource>> GetAsync()
        {

            var vehicleModels = await _vehicleModelService.ListAllAsync();
            var resources = _mapper.Map<IEnumerable<VehicleModel>, IEnumerable<VehicleModelResource>>(vehicleModels);
            
            return resources;

        }

        [HttpPost]
        public async Task<IActionResult> PostModelAsync([FromBody] SaveVehicleModelResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var vehicleModel = _mapper.Map<SaveVehicleModelResource, VehicleModel>(resource);
            var result = await _vehicleModelService.SaveModelAsync(vehicleModel);

            if (!result.Success)
                return BadRequest(result.Message);

            var vehicleModelResource = _mapper.Map<VehicleModel, VehicleModelResource>(result.VehicleModel);
            return Ok(vehicleModelResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutModelAsync(Guid id, [FromBody] SaveVehicleModelResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var model = _mapper.Map<SaveVehicleModelResource, VehicleModel>(resource);
            var result = await _vehicleModelService.UpdateModelAsync(id, model);

            if (!result.Success)
                return BadRequest(result.Message);

            var vehicleModelResource = _mapper.Map<VehicleModel, VehicleModelResource>(result.VehicleModel);
            return Ok(vehicleModelResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteModelAsync(Guid id)
        {
            var result = await _vehicleModelService.DeleteModelAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var vehicleModelService = _mapper.Map<VehicleModel, VehicleModelResource>(result.VehicleModel);
            return Ok(vehicleModelService);
        }

    }
}