using GTBA.Models;
using GTBA.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace GTBA.Services.DataStores
{
    public class GamesDataStore : BaseDataStore<Game>, IGamesDataStore
    {
        public GamesDataStore()
        {
            table = context.Games;
        }
    }
}
