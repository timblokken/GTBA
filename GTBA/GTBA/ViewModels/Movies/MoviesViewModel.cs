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
        public MoviesViewModel(Franchise franchise = null)
        {
            Title = franchise != null ? "Movies" : "GTBA";
            Movies = new ObservableCollection<Movie>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand(franchise));

            MessagingCenter.Subscribe<NewMovieViewModel, Movie>(this, "AddMovie", async (obj, movie) =>
            {
                Movies.Add(movie);
                await DataStore.AddItemAsync(movie);
                await ExecuteLoadItemsCommand(franchise);
            });

            MessagingCenter.Subscribe<MovieDetailViewModel, Movie>(this, "DeleteMovie", async (obj, movie) =>
            {
                Movies.Remove(movie);
                await DataStore.DeleteItemAsync(movie.MovieId);
                await ExecuteLoadItemsCommand(franchise);
            });
        }

        async Task ExecuteLoadItemsCommand(Franchise franchise = null)
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
                    movies = await DataStore.GetItemsByFranchiseAsync(franchise.FranchiseId);
                }
                else
                {
                    movies = await DataStore.GetItemsAsync(true);
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
