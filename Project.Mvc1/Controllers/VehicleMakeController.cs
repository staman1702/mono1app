using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Project.Service.Models;

namespace Project.Mvc1.Controllers
{
    public class VehicleMakeController : Controller
    {
        public ActionResult Index()
        {
            var vehicleMakes = ListAsync();

            return View(vehicleMakes);
        }

        public List<VehicleMake> ListAsync()
        {
          
                var resultList = new List<VehicleMake>();
                var client = new HttpClient();
                var getDataTask = client.GetAsync("http://localhost:49444/api/VehicleMake")
                    .ContinueWith(response =>
                    {
                        var result = response.Result;
                        if (result.StatusCode==System.Net.HttpStatusCode.OK)
                        {
                            var readResult = result.Content.ReadAsAsync<List<VehicleMake>>();
                            readResult.Wait();
                            resultList = readResult.Result;
                        }

                    });
                getDataTask.Wait();
                return (resultList);
            
           
        }
    }
}