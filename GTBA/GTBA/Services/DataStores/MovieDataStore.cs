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
    public class MovieDataStore : BaseDataStore<Movie>, IMovieDataStore
    {
        public MovieDataStore()
        {
            table = context.Movies;
        }

        public async Task<IEnumerable<Movie>> GetItemsByFranchiseAsync(int franId, string sorter = null)
        {
            var movies = table.Where(f => f.FranchiseId == franId).Include(m => m.Franchise);
            return await Sort(sorter, movies);
        }

        public override async Task<IEnumerable<Movie>> GetItemsAsync(bool forceRefresh = false, string sorter = null)
        {
            var movies = table.Include(m => m.Franchise);
            return await Sort(sorter, movies);
        }

        public async Task<IEnumerable<Movie>> Sort(string sorter, IIncludableQueryable<Movie,Franchise> movies)
        {
            switch (sorter)
            {
                case "AZ":
                    var az = from movie in movies
                             orderby movie.MovieName ascending
                             select movie;
                    return await az.ToListAsync();
                case "ZA":
                    var za = from movie in movies
                             orderby movie.MovieName descending
                             select movie;
                    return await za.ToListAsync();
                case "Longest":
                    var longest = from movie in movies
                             orderby movie.MovieLength descending
                             select movie;
                    return await longest.ToListAsync();
                case "Shortest":
                    var shortest = from movie in movies
                             orderby movie.MovieLength ascending
                             select movie;
                    return await shortest.ToListAsync();
                case "Seen":
                    var seen = from movie in movies
                                  orderby movie.Seen descending
                                  select movie;
                    return await seen.ToListAsync();
                case "NotSeen":
                    var notSeen = from movie in movies
                                   orderby movie.Seen ascending
                                   select movie;
                    return await notSeen.ToListAsync();
                default:
                    return await movies.ToListAsync();
            }
        }

        public async Task<IEnumerable<Movie>> GetItemsByTagsAsync(string tag, string sorter = null)
        {
            var movies = table.Where(m => m.Tags.Contains(tag)).Include(m => m.Franchise);
            return await Sort(sorter, movies);
        }

        public async Task<IEnumerable<Movie>> GetItemsByTagByFranchiseAsync(string tag, int franId, string sorter = null)
        {
            var movies = table.Where(m => m.FranchiseId == franId).Where(m => m.Tags.Contains(tag)).Include(m => m.Franchise);
            return await Sort(sorter, movies);
        }
    }
}
