using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Project.Mvc.Resources
{
    public class VehicleModelResource
    {
        [DataMember]
        [Key]
        public Guid Id { get; set; }
        [DataMember]
        [StringLength(50, ErrorMessage = "Error. Value cannot exceed 50 characters")]
        public string Name { get; set; }
        [DataMember]
        [StringLength(15, ErrorMessage = "Error. Value cannot exceed 15 characters")]
        public string Abrv { get; set; }
        public Guid VehicleMakeId { get; set; }
        public VehicleMakeResource VehicleMake { get; set; }
    }
}
