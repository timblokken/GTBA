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
    public class EpisodeDataStore : BaseDataStore<Episode>, IEpisodeDataStore
    {
        public EpisodeDataStore()
        {
            table = context.Episodes;
        }

        public async Task<IEnumerable<Episode>> GetItemsBySerieAsync(int serieId, string sorter = null)
        {
            var episodes = table.Where(f => f.SerieId == serieId).Include(e => e.Serie);
            return await Sort(sorter, episodes);
        }

        public override async Task<IEnumerable<Episode>> GetItemsAsync(bool forceRefresh = false, string sorter = null)
        {
            var episodes = table.Include(e => e.Serie);
            return await Sort(sorter, episodes);
        }

        public async Task<IEnumerable<Episode>> GetItemsByTagsAsync(string tag, string sorter = null)
        {
            var episodes = table.Where(e => e.Tags.Contains(tag)).Include(e => e.Serie);
            return await Sort(sorter, episodes);
        }

        public async Task<IEnumerable<Episode>> GetItemsByTagBySerieAsync(string tag, int franId, string sorter = null)
        {
            var episodes = table.Where(g => g.SerieId == franId).Where(g => g.Tags.Contains(tag)).Include(g => g.Serie);
            return await Sort(sorter, episodes);
        }
        public async Task<IEnumerable<Episode>> Sort(string sorter, IIncludableQueryable<Episode, Serie> episodes)
        {
            switch (sorter)
            {
                case "AZ":
                    var az = from episode in episodes
                             orderby episode.EpisodeName ascending
                             select episode;
                    return await az.ToListAsync();
                case "ZA":
                    var za = from episode in episodes
                             orderby episode.EpisodeName descending
                             select episode;
                    return await za.ToListAsync();
                case "Newest":
                    var newest = from episode in episodes
                                 orderby episode.Season descending, episode.EpisodeNr descending
                                 select episode;
                    return await newest.ToListAsync();
                case "Oldest":
                    var oldest = from episode in episodes
                                 orderby episode.Season ascending, episode.EpisodeNr ascending
                                 select episode;
                    return await oldest.ToListAsync();
                case "Seen":
                    var seen = from episode in episodes
                               orderby episode.Seen descending
                               select episode;
                    return await seen.ToListAsync();
                case "NotSeen":
                    var notSeen = from episode in episodes
                                  orderby episode.Seen ascending
                                  select episode;
                    return await notSeen.ToListAsync();
                default:
                    return await episodes.ToListAsync();
            }
        }
    }
}
