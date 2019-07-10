using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Project.Mvc1.Paging;
using Project.Mvc1.ViewModels;

namespace Project.Mvc1.Controllers
{
    public class VehicleModelController : Controller
    {

        public ActionResult Index(string sortOrder, string currentFilter, 
                                        string searchString1, string searchString2, int? pageNumber)
        {

            List<VehicleModelViewModel> vehicleModels = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:8080/api/VehicleModel");

                var responseTask = client.GetAsync("VehicleModel");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<List<VehicleModelViewModel>>();
                    readTask.Wait();

                    vehicleModels = readTask.Result;
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Server error.");
                }
            }

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
                vehicleModels = vehicleModels.Where(m => m.Name.Contains(searchString1)).ToList();
            }


            if (!String.IsNullOrEmpty(searchString2))
            {
                ViewData["SearchString2"] = searchString2;
                vehicleModels = vehicleModels.Where(m => m.VehicleMake.Name.Contains(searchString2)).ToList();
            }
            
            switch (sortOrder)
            {
                case "name_desc":
                    vehicleModels = vehicleModels.OrderByDescending(m => m.Name).ToList();
                    break;
                case "Abrv":
                    vehicleModels = vehicleModels.OrderBy(m => m.Abrv).ToList();
                    break;
                case "abrv_desc":
                    vehicleModels = vehicleModels.OrderByDescending(m => m.Abrv).ToList();
                    break;
                case "Make":
                    vehicleModels = vehicleModels.OrderBy(m => m.VehicleMake.Name).ToList();
                    break;
                case "make_desc":
                    vehicleModels = vehicleModels.OrderByDescending(m => m.VehicleMake.Name).ToList();
                    break;
                default:
                    vehicleModels = vehicleModels.OrderBy(m => m.Name).ToList();
                    break;
            }



            int pageSize = 3;

            return View(PaginatedList<VehicleModelViewModel>.Create(vehicleModels.ToList(), pageNumber ?? 1, pageSize));
        }



        public ActionResult Create()
        {
            List<VehicleMakeViewModel> vehicleMakes = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:8080/api/VehicleMake");

                var responseTask = client.GetAsync("VehicleMake");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<List<VehicleMakeViewModel>>();
                    readTask.Wait();

                    vehicleMakes = readTask.Result;
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Server error.");
                }
            }

            List<SelectListItem> makeList = new List<SelectListItem>();
            var makes =  vehicleMakes.ToList();
            
            foreach (VehicleMakeViewModel item in makes)
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
        public ActionResult Create(VehicleModelViewModel vehicleModel)
        {
            
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:8080/api/VehicleModel");

                var postTask = client.PostAsJsonAsync("VehicleModel", vehicleModel);
                postTask.Wait();

                var result = postTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Server error.");
                }

            }
          
            return View(vehicleModel);

        }

        public ActionResult Edit(Guid id)
        {
            VehicleModelViewModel vehicleModel = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:8080/api/");
                //HTTP GET
                var responseTask = client.GetAsync("VehicleModel/" + id.ToString());
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<VehicleModelViewModel>();
                    readTask.Wait();

                    vehicleModel = readTask.Result;
                }

            }

            List<VehicleMakeViewModel> vehicleMakes = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:8080/api/VehicleMake");

                var responseTask = client.GetAsync("VehicleMake");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<List<VehicleMakeViewModel>>();
                    readTask.Wait();

                    vehicleMakes = readTask.Result;
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Server error.");
                }
            }

            List<SelectListItem> makeList = new List<SelectListItem>();
            var makes = vehicleMakes.ToList();

            foreach (VehicleMakeViewModel item in makes)
            {
                makeList.Add(new SelectListItem
                {
                    Text = item.Name,
                    Value = item.Id.ToString()
                });
            }

            ViewBag.Make = makeList;

            return View(vehicleModel);
        }

        [HttpPost]
        public ActionResult Edit(Guid id, VehicleModelViewModel vehicleModel)
        {

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:8080/api/VehicleModel");

                //HTTP POST
                var putTask = client.PutAsJsonAsync("VehicleModel/" + id.ToString(), vehicleModel);
                putTask.Wait();

                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    return RedirectToAction("Index");
                }

            }                      

            return View(vehicleModel);
        }

        public ActionResult Delete(Guid id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:8080/api/");

                //HTTP DELETE
                var deleteTask = client.DeleteAsync("VehicleModel/" + id.ToString());
                deleteTask.Wait();

                var result = deleteTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    return RedirectToAction("Index");
                }
            }

            return RedirectToAction("Index");
        }


        //****
    }
}