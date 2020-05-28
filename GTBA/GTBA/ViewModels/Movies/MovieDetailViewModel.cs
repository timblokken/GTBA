using GTBA.Models;
using GTBA.Services.Interfaces;
using GTBA.Views.Movies;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace GTBA.ViewModels.Movies
{
    public class MovieDetailViewModel : BaseViewModel
    {
        public IDataStore<Movie> DataStore => DependencyService.Get<IDataStore<Movie>>();
        public Movie Movie { get; set; }
        public MovieDetailViewModel(Movie movie = null)
        {
            Title = movie?.MovieName;
            Movie = movie;

            MessagingCenter.Subscribe<EditMoviePage, Movie>(this, "EditMovie", async (obj, update) =>
            {
                this.Movie = update;
                this.Title = update.MovieName;
                await DataStore.UpdateItemAsync(update);
            });
        }
    }
}
