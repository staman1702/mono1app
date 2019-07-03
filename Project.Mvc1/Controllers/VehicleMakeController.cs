using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Project.Service.Models;
using Project.Service.Resources;

namespace Project.Mvc1.Controllers
{
    public class VehicleMakeController : Controller
    {
        public ActionResult Index()
        {
            List<VehicleMake> vehicleMakes = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:49444/api/VehicleMake");

                var responseTask = client.GetAsync("VehicleMake");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<List<VehicleMake>>();
                    readTask.Wait();

                    vehicleMakes = readTask.Result;
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Server error.");
                }
            }

            return View(vehicleMakes);
        }


        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(VehicleMake vehicleMake)
        {


            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:49444/api/VehicleMake");

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
            VehicleMake vehicleMake = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:49444/api/");
                //HTTP GET
                var responseTask = client.GetAsync("VehicleMake/" + id.ToString());
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<VehicleMake>();
                    readTask.Wait();

                    vehicleMake = readTask.Result;
                }
                
            }
            return View(vehicleMake);
        }

        [HttpPost]
        public ActionResult Edit(Guid id, VehicleMake vehicleMake)
        {
            
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:49444/api/VehicleMake");

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
                client.BaseAddress = new Uri("http://localhost:49444/api/");

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