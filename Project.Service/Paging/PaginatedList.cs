using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Service.Paging
{
    public class PaginatedList<T> : List<T>
    {
        public int CurrentPage { get; set; }

        public int TotalPages { get; set; }

        public bool HasNextPage
        {
            get { return (CurrentPage < TotalPages); }
        }

        public bool HasPreviousPage
        {
            get { return (CurrentPage > 1); }
        }


        public PaginatedList(List<T> items, int currentPage, int objectsPerPage, int totalObjects)
        {
            CurrentPage = currentPage;
            TotalPages = (int)Math.Ceiling(totalObjects / (double)objectsPerPage);

            AddRange(items);
        }



        public static async Task<PaginatedList<T>> CreateAsync(IQueryable<T> source, int currentPage, int objectsPerPage)
        {
            var items = await source.Skip((currentPage - 1) * objectsPerPage)
                                    .Take(objectsPerPage)
                                    .ToListAsync();

            int totalObjects = source.Count();

            return new PaginatedList<T>(items, currentPage, objectsPerPage, totalObjects);
        }
    }
}
