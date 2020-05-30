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
    public class EpisodeDataStore : BaseDataStore<Episode>, IEpisodeDataStore
    {
        public EpisodeDataStore()
        {
            table = context.Episodes;
        }

        public async Task<IEnumerable<Episode>> GetItemsBySerieAsync(int serieId)
        {
            return await table.Where(f => f.SerieId == serieId).ToListAsync();
        }

        public override async Task<IEnumerable<Episode>> GetItemsAsync(bool forceRefresh = false)
        {
            var episodes = table.Include(e => e.Serie);
            //var test = await movies.ToListAsync();
            return await episodes.ToListAsync();
        }
    }
}
