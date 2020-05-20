using GTBA.Models;
using GTBA.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace GTBA.Services.DataStores
{
    public class MovieDataStore : BaseDataStore<Movie>, IMovieDataStore
    {
        public MovieDataStore()
        {
            table = context.Movies;
        }
    }
}
