using GTBA.Models;
using GTBA.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTBA.Services.DataStores
{
    public class MovieDataStore : BaseDataStore<Movie>, IMovieDataStore
    {
        public MovieDataStore()
        {
            table = context.Movies;
        }

        public async Task<IEnumerable<Movie>> GetItemsByFranchiseAsync(int franId)
        {
            return await table.Where(f => f.FranchiseId == franId).Include(m => m.Franchise).ToListAsync();
        }

        public override async Task<IEnumerable<Movie>> GetItemsAsync(bool forceRefresh = false)
        {
            var movies = table.Include(m => m.Franchise);
            return await movies.ToListAsync();
        }
    }
}
