using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project.Service0.Domain.Models;

namespace Project.Service0.Domain.Services.Communication
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

        /// <param name="item">Saved item.</param>
        
        public VehicleResponse(T item) : this(true, string.Empty, item)
        { }

       
        /// <param name="message">Error message.</param>
      
        public VehicleResponse(string message) : this(false, message, default)
        { }
    }
}
