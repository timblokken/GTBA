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
            switch (sorter)
            {
                case "AZ":
                    var az = from franchise in table
                             orderby franchise.FranchiseName ascending
                             select franchise;
                    return await az.ToListAsync();
                case "ZA":
                    var za = from franchise in table
                             orderby franchise.FranchiseName descending
                             select franchise;
                    return await za.ToListAsync();
                default:
                    return await table.ToListAsync();
            }
        }
    }
}
