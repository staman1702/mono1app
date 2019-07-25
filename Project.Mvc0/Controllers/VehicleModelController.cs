﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.Service0.Domain.Services;
using AutoMapper;
using Project.Mvc0.Resources;
using Project.Mvc0.Extensions;
using Project.Service0.Domain.Models;
using Project.Service0.Common;

namespace Project.Mvc0.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleModelController : ControllerBase
    {

        private readonly IVehicleModelService _vehicleModelService;
        private readonly IMapper _mapper;

        public VehicleModelController(IVehicleModelService vehicleModelService, IMapper mapper)
        {
            _vehicleModelService = vehicleModelService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {

            FilteringModel filteringModel = new FilteringModel();
            PagingModel pagingModel = new PagingModel();
            SortingModel sortingModel = new SortingModel();
            var vehicleModels = await _vehicleModelService.ListAllAsync(pagingModel, sortingModel, filteringModel);
            var resources = _mapper.Map<IEnumerable<VehicleModel>, IEnumerable<VehicleModelResource>>(vehicleModels);
            var jsonResponse = new
            {
                resources,
                queryParams = new
                {
                    pageNo = vehicleModels.CurrentPage,
                    totalPages = vehicleModels.TotalPages,
                    hasNextPage = vehicleModels.HasNextPage,
                    hasPreviousPage = vehicleModels.HasPreviousPage,
                    currentFilter = filteringModel.Filter ?? "none",
                    sortOrder = sortingModel.SortBy ?? "id"
                }
            };
            return Ok(jsonResponse);

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