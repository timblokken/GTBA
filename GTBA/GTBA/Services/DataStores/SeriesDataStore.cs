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
    public class SeriesDataStore : BaseDataStore<Serie>, ISeriesDataStore
    {
        public SeriesDataStore()
        {
            table = context.Series;
        }

        public async Task<IEnumerable<Serie>> GetItemsByFranchiseAsync(int franId)
        {
            var series = await table.Where(f => f.FranchiseId == franId).Include(s => s.Franchise).ToListAsync();
            return series;
        }

        public override async Task<IEnumerable<Serie>> GetItemsAsync(bool forceRefresh = false, string sorter = null)
        {
            var series = table.Include(s => s.Franchise);
            return await series.ToListAsync();
        }
    }
}
