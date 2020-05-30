using GTBA.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GTBA.Services.Interfaces
{
    public interface IEpisodeDataStore : IDataStore<Episode>
    {
        Task<IEnumerable<Episode>> GetItemsBySerieAsync(int serieId);
    }
}
