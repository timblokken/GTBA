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
    public class GamesDataStore : BaseDataStore<Game>, IGamesDataStore
    {
        public GamesDataStore()
        {
            table = context.Games;
        }

        public async Task<IEnumerable<Game>> GetItemsByFranchiseAsync(int franId, string sorter = null)
        {
            var games = table.Where(g => g.FranchiseId == franId).Include(g => g.Franchise);
            return await Sort(sorter, games);
        }

        public override async Task<IEnumerable<Game>> GetItemsAsync(bool forceRefresh = false, string sorter = null)
        {
            var games = table.Include(g => g.Franchise);
            return await Sort(sorter, games);
        }

        public async Task<IEnumerable<Game>> Sort(string sorter, IIncludableQueryable<Game, Franchise> games)
        {
            switch (sorter)
            {
                case "AZ":
                    var az = from game in games
                             orderby game.GameName ascending
                             select game;
                    return await az.ToListAsync();
                case "ZA":
                    var za = from game in games
                             orderby game.GameName descending
                             select game;
                    return await za.ToListAsync();
                default:
                    return await games.ToListAsync();
            }
        }

        public async Task<IEnumerable<Game>> GetItemsByTagsAsync(string tag, string sorter = null)
        {
            var games = table.Where(g => g.Tags.Contains(tag)).Include(g => g.Franchise);
            return await Sort(sorter, games);
        }

        public async Task<IEnumerable<Game>> GetItemsByTagByFranchiseAsync(string tag, int franId, string sorter = null)
        {
            var games = table.Where(g => g.FranchiseId == franId).Where(g => g.Tags.Contains(tag)).Include(g => g.Franchise);
            return await Sort(sorter, games);
        }
    }
}
