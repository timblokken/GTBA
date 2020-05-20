using GTBA.Models;
using GTBA.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace GTBA.Services.DataStores
{
    public class SeriesDataStore : BaseDataStore<Serie>, ISeriesDataStore
    {
        public SeriesDataStore()
        {
            table = context.Series;
        }
    }
}
