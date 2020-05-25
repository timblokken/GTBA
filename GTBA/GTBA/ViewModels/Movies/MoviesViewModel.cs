using GTBA.Models;
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
        public IDataStore<Movie> DataStore => DependencyService.Get<IDataStore<Movie>>();
        public ObservableCollection<Movie> Movies { get; set; }
        public Command LoadItemsCommand { get; set; }
        public MoviesViewModel(Franchise franchise = null)
        {
            Title = franchise!=null ? "Movies" : "GTBA";
            //Title = franchise?.FranchiseName : "GTBA";

            //if (franchise != null)
            //{
            //    Title = franchise.FranchiseName;
            //}
            //else
            //{
            //    Title = "GTBA";
            //}

            Movies = new ObservableCollection<Movie>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            MessagingCenter.Subscribe<NewMovieViewModel, Movie>(this, "AddMovie", async (obj, movie) =>
            {
                var newItem = movie as Movie;
                Movies.Add(newItem);
                await DataStore.AddItemAsync(newItem);
            });
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Movies.Clear();
                var movies = await DataStore.GetItemsAsync(true);
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
