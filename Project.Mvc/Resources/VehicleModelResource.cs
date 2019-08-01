﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Mvc.Resources
{
    public class VehicleModelResource
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Abrv { get; set; }
        public Guid VehicleMakeId { get; set; }
        public VehicleMakeResource VehicleMake { get; set; }
    }
}