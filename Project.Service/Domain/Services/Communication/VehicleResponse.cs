using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project.Service.Domain.Models;

namespace Project.Service.Domain.Services.Communication
{
    public class VehicleResponse<T> : BaseResponse
    {
        public T VehicleMake { get; private set; }
        public T VehicleModel { get; private set; }


        private VehicleResponse(bool success, string message, T item) : base(success, message)
        {
            VehicleMake = item;
            VehicleModel = item;
        }

        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="item">Saved item.</param>
        /// <returns>Response.</returns>
        public VehicleResponse(T item) : this(true, string.Empty, item)
        { }

        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public VehicleResponse(string message) : this(false, message, default)
        { }
    }
}
