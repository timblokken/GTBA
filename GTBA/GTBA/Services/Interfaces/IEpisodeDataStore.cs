using GTBA.Models;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GTBA.Services.Interfaces
{
    public interface IEpisodeDataStore : IDataStore<Episode>
    {
        Task<IEnumerable<Episode>> GetItemsBySerieAsync(int serieId,string sorter = null);
        Task<IEnumerable<Episode>> Sort(string sorter, IIncludableQueryable<Episode, Serie> episodes);
        Task<IEnumerable<Episode>> GetItemsByTagBySerieAsync(string tag, int franId, string sorter = null);
    }
}
