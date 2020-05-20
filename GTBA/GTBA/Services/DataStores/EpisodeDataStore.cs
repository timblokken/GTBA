using GTBA.Models;
using GTBA.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace GTBA.Services.DataStores
{
    public class EpisodeDataStore : BaseDataStore<Episode>, IEpisodeDataStore
    {
        public EpisodeDataStore()
        {
            table = context.Episodes;
        }
    }
}
