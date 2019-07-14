using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Service.Common
{
    public class PagingModel
    {
        public int? CurrentPage { get; set; }

        public int? TotalPages { get; set; }
    }
}
