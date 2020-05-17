using GTBA.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GTBA.Services
{
    public class FranchisesDataStore : BaseDataStore<Franchise>, IFranchisesDataStore
    {
        public FranchisesDataStore()
        {
            table = context.Franchises;
        }
    }
}
