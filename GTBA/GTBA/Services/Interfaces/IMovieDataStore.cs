using GTBA.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GTBA.Services.Interfaces
{
    public interface IMovieDataStore : IDataStore<Movie>
    {
        Task<IEnumerable<Movie>> GetItemsByFranchiseAsync(int franId);
    }
}
