using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project.Service.Domain.Models;

namespace Project.Service.Domain.Services.Communication
{
    public class VehicleMakeResponse : BaseResponse
    {
        public VehicleMake VehicleMake { get; private set; }

        private VehicleMakeResponse(bool success, string message, VehicleMake vehicleMake) : base(success, message)
        {
            VehicleMake = vehicleMake;
        }

        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="vehicleMake">Saved vehicleMake.</param>
        /// <returns>Response.</returns>
        public VehicleMakeResponse(VehicleMake vehicleMake) : this(true, string.Empty, vehicleMake)
        { }

        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public VehicleMakeResponse(string message) : this(false, message, null)
        { }
    }
}
