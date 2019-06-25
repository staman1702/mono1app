using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace Project.Service.Resources
{
    public class SaveVehicleModelResource
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(15)]
        public string Abrv { get; set; }
        public int VehicleMakeId { get; set; }
    }
}
