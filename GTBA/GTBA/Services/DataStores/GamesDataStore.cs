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
    public class GamesDataStore : BaseDataStore<Game>, IGamesDataStore
    {
        public GamesDataStore()
        {
            table = context.Games;
        }

        public async Task<IEnumerable<Game>> GetItemsByFranhciseAsync(int franId)
        {
            return await table.Where(f => f.FranchiseId == franId).ToListAsync();
        }

        public override async Task<IEnumerable<Game>> GetItemsAsync(bool forceRefresh = false)
        {
            var games = table.Include(g => g.Franchise);
            return await games.ToListAsync();
        }
    }
}
