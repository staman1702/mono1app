using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.Service.Services;
using AutoMapper;
using Project.Service.Resources;
using Project.Service.Extensions;
using Project.Service.Models;

namespace Project.Service.Controllers
{
    [Route("api/VehicleMake")]
    [ApiController]
    public class VehicleMakeController : ControllerBase
    {

        private readonly IVehicleMakeService _vehicleMakeService;        
        private readonly IMapper _mapper;

        public VehicleMakeController(IVehicleMakeService vehicleMakeService, IMapper mapper)
        {
            _vehicleMakeService = vehicleMakeService;
            _mapper = mapper;
        }

        [HttpGet]
        //[Route("api/VehicleMake")]
        public async Task<IEnumerable<VehicleMakeResource>> ListAsync()
        {
            var vehicleMakes = await _vehicleMakeService.ListAsync();
            var resources = _mapper.Map<IEnumerable<VehicleMake>, IEnumerable<VehicleMakeResource>>(vehicleMakes);

            return resources;
        }

        [HttpPost]
        //[Route("api/VehicleMake/Create")]
        public async Task<IActionResult> PostAsync([FromBody] SaveVehicleMakeResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var vehicleMake = _mapper.Map<SaveVehicleMakeResource, VehicleMake>(resource);
            var result = await _vehicleMakeService.SaveAsync(vehicleMake);

            if (!result.Success)
                return BadRequest(result.Message);

            var vehicleMakeResource = _mapper.Map<VehicleMake, VehicleMakeResource>(result.VehicleMake);
            return Ok(vehicleMakeResource);
        }

        [HttpPut("{id}")]
        //[Route("api/VehicleMake/Edit/")]
        public async Task<IActionResult> PutAsync(Guid id, [FromBody] SaveVehicleMakeResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var make = _mapper.Map<SaveVehicleMakeResource, VehicleMake>(resource);
            var result = await _vehicleMakeService.UpdateAsync(id, make);

            if (!result.Success)
                return BadRequest(result.Message);

            var vehicleMakeResource = _mapper.Map<VehicleMake, VehicleMakeResource>(result.VehicleMake);
            return Ok(vehicleMakeResource);
        }

        [HttpDelete("{id}")]
        //[Route("api/VehicleMake/Delete/")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            var result = await _vehicleMakeService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var vehicleMakeResource = _mapper.Map<VehicleMake, VehicleMakeResource>(result.VehicleMake);
            return Ok(vehicleMakeResource);
        }
    }
}