using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Mvc0.Resources
{
    public class SaveVehicleMakeResource
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(15)]
        public string Abrv { get; set; }
    }
}
