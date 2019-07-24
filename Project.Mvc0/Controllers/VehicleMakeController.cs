using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Project.Mvc0.Resources;
using Project.Mvc0.Extensions;
using Project.Service0.Domain.Models;
using Project.Service0.Domain.Services;
using Project.Service0.Common;
using Project.Service0.Paging;

namespace Project.Mvc0.Controllers
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
        public async Task<IActionResult> GetAsync()
        {

            FilteringModel filteringModel = new FilteringModel();
            PagingModel pagingModel = new PagingModel();
            SortingModel sortingModel = new SortingModel();
            var vehicleMakes = await _vehicleMakeService.ListAllAsync(pagingModel, sortingModel, filteringModel);
            var resources = _mapper.Map<IEnumerable<VehicleMake>, IEnumerable<VehicleMakeResource>>(vehicleMakes);
            var jsonResponse = new
            {
                data = resources,
                queryParams = new
                {
                    pageNo = vehicleMakes.CurrentPage,
                    totalPages = vehicleMakes.TotalPages,
                    hasNextPage = vehicleMakes.HasNextPage,
                    hasPreviousPage = vehicleMakes.HasPreviousPage,
                    currentFilter = filteringModel.Filter ?? "none",
                    sortOrder = sortingModel.SortBy ?? "id"
                }
            };

            

            return this.Ok(jsonResponse);

        }       

        [HttpPost]
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