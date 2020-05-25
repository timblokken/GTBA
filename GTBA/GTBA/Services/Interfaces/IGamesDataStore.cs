using GTBA.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GTBA.Services.Interfaces
{
    public interface IGamesDataStore : IDataStore<Game>
    {
        Task<IEnumerable<Game>> GetItemsByFranhciseAsync(int franId);
    }
}
