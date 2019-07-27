using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Project.Mvc0.Resources;
using Project.Mvc0.Extensions;
using Project.Service0.Domain.Models;
using Project.Service0.Domain.Services;
using Project.Mvc0.Paging;

namespace Project.Mvc0.Controllers
{
    
    public class VehicleMakeController : Controller
    {

        private readonly IVehicleMakeService _vehicleMakeService;        
        private readonly IMapper _mapper;

        public VehicleMakeController(IVehicleMakeService vehicleMakeService, IMapper mapper)
        {
            _vehicleMakeService = vehicleMakeService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult> Index(string sortOrder, string currentFilter, string searchString, int? pageNumber)
        {

            var vehicleMakes = await _vehicleMakeService.ListAllAsync();
            var resources = _mapper.Map<IEnumerable<VehicleMake>, IEnumerable<VehicleMakeResource>>(vehicleMakes);

            ViewData["CurrentSort"] = sortOrder;
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["AbrvSortParm"] = sortOrder == "Abrv" ? "abrv_desc" : "Abrv";

            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;

            if (!String.IsNullOrEmpty(searchString))
            {
                resources = resources.Where(m => m.Name.Contains(searchString)).ToList();
            }

            switch (sortOrder)
            {
                case "name_desc":
                    resources = resources.OrderByDescending(m => m.Name).ToList();
                    break;
                case "Abrv":
                    resources = resources.OrderBy(m => m.Abrv).ToList();
                    break;
                case "abrv_desc":
                    resources = resources.OrderByDescending(m => m.Abrv).ToList();
                    break;
                default:
                    resources = resources.OrderBy(m => m.Name).ToList();
                    break;
            }

            int pageSize = 3;

            return View(PaginatedList<VehicleMakeResource>.Create(resources.ToList(), pageNumber ?? 1, pageSize));

        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(SaveVehicleMakeResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var vehicleMake = _mapper.Map<SaveVehicleMakeResource, VehicleMake>(resource);
            var result = await _vehicleMakeService.SaveAsync(vehicleMake);
                        
            if (result.Success)
            {
                return RedirectToAction("Index");
            }
            if (!result.Success)
                return BadRequest(result.Message);

            var vehicleMakeResource = _mapper.Map<VehicleMake, VehicleMakeResource>(result.VehicleMake);
                       

            return View(vehicleMakeResource);
        }

        [HttpGet]
        public async Task<ActionResult> Edit(Guid id)
        {                      
            var result = await _vehicleMakeService.FindAsync(id);            
            var vehicleMakeResource = _mapper.Map<VehicleMake, VehicleMakeResource>(result);

            return View(vehicleMakeResource);
        }

                
        public async Task<IActionResult> Edit(Guid id, SaveVehicleMakeResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var make = _mapper.Map<SaveVehicleMakeResource, VehicleMake>(resource);
            var result = await _vehicleMakeService.UpdateAsync(id, make);

            if (result.Success)
            {
                return RedirectToAction("Index");
            }
            if (!result.Success)
                return BadRequest(result.Message);

            var vehicleMakeResource = _mapper.Map<VehicleMake, VehicleMakeResource>(result.VehicleMake);

            return View(vehicleMakeResource);
        }

        
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _vehicleMakeService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);
                       

            return RedirectToAction("Index");
        }        

    }
}