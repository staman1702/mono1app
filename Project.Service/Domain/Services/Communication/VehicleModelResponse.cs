using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project.Service.Domain.Models;


namespace Project.Service.Domain.Services.Communication
{
    public class VehicleModelResponse : BaseResponse
    {
        public VehicleModel VehicleModel { get; private set; }

        private VehicleModelResponse(bool success, string message, VehicleModel vehicleModel) : base(success, message)
        {
            VehicleModel = vehicleModel;
        }

        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="vehicleModel">Saved vehicleMake.</param>
        /// <returns>Response.</returns>
        public VehicleModelResponse(VehicleModel vehicleModel) : this(true, string.Empty, vehicleModel)
        { }

        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public VehicleModelResponse(string message) : this(false, message, null)
        { }
    }
}
