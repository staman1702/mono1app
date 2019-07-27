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
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Project.Mvc0.Controllers
{

    public class VehicleModelController : Controller
    {
        private readonly IVehicleModelService _vehicleModelService;
        private readonly IVehicleMakeService _vehicleMakeService;

        private readonly IMapper _mapper;

        public VehicleModelController(IVehicleModelService vehicleModelService, 
                                        IVehicleMakeService vehicleMakeService, IMapper mapper)
        {
            _vehicleModelService = vehicleModelService;
            _vehicleMakeService = vehicleMakeService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult> Index(string sortOrder, string currentFilter, string searchString1, 
                                                                    string searchString2, int? pageNumber)
        {
            var vehicleModels = await _vehicleModelService.ListAllAsync();
            var resources = _mapper.Map<IEnumerable<VehicleModel>, IEnumerable<VehicleModelResource>>(vehicleModels);

            ViewData["CurrentSort"] = sortOrder;
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["AbrvSortParm"] = sortOrder == "Abrv" ? "abrv_desc" : "Abrv";
            ViewData["MakeSortParm"] = sortOrder == "Make" ? "make_desc" : "Make";


            if (searchString1 != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString1 = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString1;

            if (!String.IsNullOrEmpty(searchString1))
            {
                ViewData["SearchString1"] = searchString1;
                resources = resources.Where(m => m.Name.Contains(searchString1)).ToList();
            }


            if (!String.IsNullOrEmpty(searchString2))
            {
                ViewData["SearchString2"] = searchString2;
                resources = resources.Where(m => m.VehicleMake.Name.Contains(searchString2)).ToList();
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
                case "Make":
                    resources = resources.OrderBy(m => m.VehicleMake.Name).ToList();
                    break;
                case "make_desc":
                    resources = resources.OrderByDescending(m => m.VehicleMake.Name).ToList();
                    break;
                default:
                    resources = resources.OrderBy(m => m.Name).ToList();
                    break;
            }



            int pageSize = 3;

            return View(PaginatedList<VehicleModelResource>.Create(resources.ToList(), pageNumber ?? 1, pageSize));
        }

        [HttpGet]
        public async Task<ActionResult> Create()
        {
            var vehicleMakes = await _vehicleMakeService.ListAllAsync();
            var resources = _mapper.Map<IEnumerable<VehicleMake>, IEnumerable<VehicleMakeResource>>(vehicleMakes);

            List<SelectListItem> makeList = new List<SelectListItem>();
            var makes = resources.ToList();

            foreach (VehicleMakeResource item in makes)
            {
                makeList.Add(new SelectListItem
                {
                    Text = item.Name,
                    Value = item.Id.ToString()
                });
            }

            ViewBag.Make = makeList;

            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(SaveVehicleModelResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var vehicleModel = _mapper.Map<SaveVehicleModelResource, VehicleModel>(resource);
            var result = await _vehicleModelService.SaveModelAsync(vehicleModel);

            if (result.Success)
            {
                return RedirectToAction("Index");
            }
            if (!result.Success)
                return BadRequest(result.Message);

            var vehicleModelResource = _mapper.Map<VehicleModel, VehicleModelResource>(result.VehicleModel);

            return View(vehicleModelResource);
        }

        [HttpGet]
        public async Task<ActionResult> Edit(Guid id)
        {
            var result = await _vehicleModelService.FindModelAsync(id);
            var vehicleModelResource = _mapper.Map<VehicleModel, VehicleModelResource>(result);

            var vehicleMakes = await _vehicleMakeService.ListAllAsync();
            var makeResources = _mapper.Map<IEnumerable<VehicleMake>, IEnumerable<VehicleMakeResource>>(vehicleMakes);

            List<SelectListItem> makeList = new List<SelectListItem>();
            var makes = makeResources.ToList();

            foreach (VehicleMakeResource item in makes)
            {
                makeList.Add(new SelectListItem
                {
                    Text = item.Name,
                    Value = item.Id.ToString()
                });
            }

            ViewBag.Make = makeList;

            return View(vehicleModelResource);
        }

        public async Task<IActionResult> Edit(Guid id, SaveVehicleModelResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var model = _mapper.Map<SaveVehicleModelResource, VehicleModel>(resource);
            var result = await _vehicleModelService.UpdateModelAsync(id, model);

            if (result.Success)
            {
                return RedirectToAction("Index");
            }
            if (!result.Success)
                return BadRequest(result.Message);

            var vehicleModelResource = _mapper.Map<VehicleModel, VehicleModelResource>(result.VehicleModel);

            return View(vehicleModelResource);
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _vehicleModelService.DeleteModelAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            return RedirectToAction("Index");
        }

    }
}