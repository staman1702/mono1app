using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using Project.Mvc1.Paging;
using Project.Mvc1.ViewModels;

namespace Project.Mvc1.Controllers
{
    public class VehicleMakeController : Controller
    {
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? pageNumber)
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
                vehicleMakes = vehicleMakes.Where(m => m.Name.Contains(searchString)).ToList();
            }

            switch (sortOrder)
            {
                case "name_desc":
                    vehicleMakes = vehicleMakes.OrderByDescending(m => m.Name).ToList();
                    break;
                case "Abrv":
                    vehicleMakes = vehicleMakes.OrderBy(m => m.Abrv).ToList();
                    break;
                case "abrv_desc":
                    vehicleMakes = vehicleMakes.OrderByDescending(m => m.Abrv).ToList();
                    break;
                default:
                    vehicleMakes = vehicleMakes.OrderBy(m => m.Name).ToList();
                    break;
            }

            int pageSize = 3;

            return View(PaginatedList<VehicleMakeViewModel>.Create(vehicleMakes.ToList(), pageNumber ?? 1, pageSize));
        }
    


        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(VehicleMakeViewModel vehicleMake)
        {


            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:8080/api/VehicleMake");

                var postTask = client.PostAsJsonAsync("VehicleMake", vehicleMake);
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

            return View(vehicleMake);

        }

        public ActionResult Edit(Guid id)
        {
            VehicleMakeViewModel vehicleMake = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:8080/api/");
                //HTTP GET
                var responseTask = client.GetAsync("VehicleMake/" + id.ToString());
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<VehicleMakeViewModel>();
                    readTask.Wait();

                    vehicleMake = readTask.Result;
                }
                
            }
            return View(vehicleMake);
        }

        [HttpPost]
        public ActionResult Edit(Guid id, VehicleMakeViewModel vehicleMake)
        {
            
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:8080/api/VehicleMake");

                //HTTP POST
                var putTask = client.PutAsJsonAsync("VehicleMake/" + id.ToString(), vehicleMake);
                putTask.Wait();

                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    return RedirectToAction("Index");
                }
               
            }
            return View(vehicleMake);
        }

        public ActionResult Delete(Guid id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:8080/api/");

                //HTTP DELETE
                var deleteTask = client.DeleteAsync("VehicleMake/" + id.ToString());
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