using GTBA.Models;
using GTBA.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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

        //public override async Task<IEnumerable<Franchise>> GetItemsAsync(bool forceRefresh = false)
        //{
        //    var test2 = table.Include(f => f.Games);
        //    var test = await test2.ToListAsync();
        //    return test;
        //}
    }
}
