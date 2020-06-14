using GTBA.Models;
using GTBA.Services.DataStores;
using GTBA.Services.Interfaces;
using GTBA.ViewModels.Movies;
using GTBA.Views.Movies;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace GTBA.ViewModels
{
    public class MoviesViewModel : BaseViewModel
    {
        public IMovieDataStore DataStore => DependencyService.Get<IMovieDataStore>();
        public ObservableCollection<Movie> Movies { get; set; }
        public Command LoadItemsCommand { get; set; }
        public Franchise franchise;

        public MoviesViewModel(Franchise franchise = null)
        {
            Title = franchise != null ? "Movies" : "GTBA";
            this.franchise = franchise;
            Movies = new ObservableCollection<Movie>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand(franchise));
            SortCommand = new Command(async (parameter) => await ExecuteLoadItemsCommand(franchise,(string)parameter));

            MessagingCenter.Subscribe<NewMovieViewModel, Movie>(this, "AddMovie", async (obj, movie) =>
            {
                Movies.Add(movie);
                await DataStore.AddItemAsync(movie);
                await ExecuteLoadItemsCommand(franchise);
            });

            MessagingCenter.Subscribe<MovieDetailViewModel, Movie>(this, "DeleteMovie", async (obj, movie) =>
            {
                await DeleteMovie(movie);
            });
        }

        public async Task DeleteMovie(Movie movie)
        {
            Movies.Remove(movie);
            await DataStore.DeleteItemAsync(movie.MovieId);
            await ExecuteLoadItemsCommand(franchise);
        }

        public async Task UpdateMovie(Movie movie)
        {
            await DataStore.UpdateItemAsync(movie);
        }

        async Task ExecuteLoadItemsCommand(Franchise franchise = null, string sorter = null)
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Movies.Clear();
                IEnumerable<Movie> movies;
                if (franchise != null)
                {
                    movies = await DataStore.GetItemsByFranchiseAsync(franchise.FranchiseId,sorter);
                }
                else
                {
                    movies = await DataStore.GetItemsAsync(true,sorter);
                }
                foreach (var movie in movies)
                {
                    Movies.Add(movie);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public async Task ExecutePerformSearchCommand(string search, Franchise franchise = null, string sorter = null)
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Movies.Clear();
                IEnumerable<Movie> movies;
                if (franchise != null)
                {
                    movies = await DataStore.GetItemsByTagByFranchiseAsync(search, franchise.FranchiseId, sorter);
                }
                else
                {
                    movies = await DataStore.GetItemsByTagsAsync(search, sorter);
                }
                foreach (var movie in movies)
                {
                    Movies.Add(movie);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
