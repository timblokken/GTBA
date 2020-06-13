using GTBA.Models;
using GTBA.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
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

        public async Task<IEnumerable<Serie>> GetItemsByFranchiseAsync(int franId, string sorter = null)
        {
            var series = table.Where(f => f.FranchiseId == franId).Include(s => s.Franchise);
            return await Sort(sorter, series);
        }

        public override async Task<IEnumerable<Serie>> GetItemsAsync(bool forceRefresh = false, string sorter = null)
        {
            var series = table.Include(s => s.Franchise);
            return await Sort(sorter, series);
        }

        public async Task<IEnumerable<Serie>> Sort(string sorter, IIncludableQueryable<Serie, Franchise> series)
        {
            switch (sorter)
            {
                case "AZ":
                    var az = from serie in series
                             orderby serie.SerieName ascending
                             select serie;
                    return await az.ToListAsync();
                case "ZA":
                    var za = from serie in series
                             orderby serie.SerieName descending
                             select serie;
                    return await za.ToListAsync();
                case "LongEps":
                    var longest = from serie in series
                                  orderby serie.EpisodeLength descending
                                  select serie;
                    return await longest.ToListAsync();
                case "ShortEps":
                    var shortest = from serie in series
                                   orderby serie.EpisodeLength ascending
                                   select serie;
                    return await shortest.ToListAsync();
                case "Seen":
                    var seen = from serie in series
                               orderby serie.Seen descending
                               select serie;
                    return await seen.ToListAsync();
                case "NotSeen":
                    var notSeen = from serie in series
                                  orderby serie.Seen ascending
                                  select serie;
                    return await notSeen.ToListAsync();
                case "MostSeasons":
                    var mostSeasons = from serie in series
                               orderby serie.Seasons descending
                               select serie;
                    return await mostSeasons.ToListAsync();
                case "LeastSeasons":
                    var leastSeasons = from serie in series
                                  orderby serie.Seasons ascending
                                  select serie;
                    return await leastSeasons.ToListAsync();
                case "MostEps":
                    var mostEps = from serie in series
                                      orderby serie.NrOfEpisodes descending
                                      select serie;
                    return await mostEps.ToListAsync();
                case "LeastEps":
                    var leastEps = from serie in series
                                       orderby serie.NrOfEpisodes ascending
                                       select serie;
                    return await leastEps.ToListAsync();
                default:
                    return await series.ToListAsync();
            }
        }

        public Task<IEnumerable<Serie>> GetItemsByTagsAsync(string tag, string sorter = null)
        {
            throw new NotImplementedException();
        }
    }
}
