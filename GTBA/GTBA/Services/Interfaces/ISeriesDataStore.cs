using GTBA.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GTBA.Services.Interfaces
{
    public interface ISeriesDataStore : IDataStore<Serie>
    {
        Task<IEnumerable<Serie>> GetItemsByFranhciseAsync(int franId);
    }
}
