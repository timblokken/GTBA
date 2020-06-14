using GTBA.Models;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GTBA.Services.Interfaces
{
    public interface ISeriesDataStore : IDataStore<Serie>
    {
        Task<IEnumerable<Serie>> GetItemsByFranchiseAsync(int franId, string sorter = null);
        Task<IEnumerable<Serie>> Sort(string sorter, IIncludableQueryable<Serie, Franchise> series);
        Task<IEnumerable<Serie>> GetItemsByTagByFranchiseAsync(string tag, int franId, string sorter = null);
    }
}
