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
    }
}
