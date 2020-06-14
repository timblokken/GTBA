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
    public class FranchisesDataStore : BaseDataStore<Franchise>, IFranchisesDataStore
    {
        public FranchisesDataStore()
        {
            table = context.Franchises;
        }


        public override async Task<IEnumerable<Franchise>> GetItemsAsync(bool forceRefresh = false, string sorter = null)
        {
            var franchises = table;
            return await Sort(sorter, franchises);
        }

        public async Task<IEnumerable<Franchise>> GetItemsByTagsAsync(string tag, string sorter = null)
        {
            var franchises = table.Where(f => f.Tags.Contains(tag));
            return await Sort(sorter, franchises);
        }

        public async Task<IEnumerable<Franchise>> Sort(string sorter, IQueryable<Franchise> franchises)
        {
            switch (sorter)
            {
                case "AZ":
                    var az = from franchise in franchises
                             orderby franchise.FranchiseName ascending
                             select franchise;
                    return await az.ToListAsync();
                case "ZA":
                    var za = from franchise in franchises
                             orderby franchise.FranchiseName descending
                             select franchise;
                    return await za.ToListAsync();
                default:
                    return await franchises.ToListAsync();
            }
        }
    }
}

