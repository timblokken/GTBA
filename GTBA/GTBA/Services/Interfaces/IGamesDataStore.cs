using GTBA.Models;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GTBA.Services.Interfaces
{
    public interface IGamesDataStore : IDataStore<Game>
    {
        Task<IEnumerable<Game>> GetItemsByFranchiseAsync(int franId, string sorter = null);
        Task<IEnumerable<Game>> Sort(string sorter, IIncludableQueryable<Game, Franchise> games);
        Task<IEnumerable<Game>> GetItemsByTagByFranchiseAsync(string tag, int franId, string sorter = null);
    }
}
