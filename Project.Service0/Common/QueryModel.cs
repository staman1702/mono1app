using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Service0.Common
{
    public class QueryModel
    {
        public int? CurrentPage { get; set; }

        public int? ObjectsPerPage { get; set; }

        public string Filter { get; set; }

        public string SortBy { get; set; }
    }
}
