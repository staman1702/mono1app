using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Mvc1.ViewModels
{
    public class VehicleMakeViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Abrv { get; set; }
        public IList<VehicleModelViewModel> VehicleModels { get; set; } = new List<VehicleModelViewModel>();
    }
}
