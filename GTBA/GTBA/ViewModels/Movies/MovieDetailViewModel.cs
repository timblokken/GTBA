﻿using GTBA.Models;
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
        public IDataStore<Movie> DataStore1 => DependencyService.Get<IDataStore<Movie>>();
        public Movie Movie { get; set; }
        public MovieDetailViewModel(Movie movie = null)
        {
            Title = movie?.MovieName;
            Movie = movie;

            MessagingCenter.Subscribe<EditMoviePage, Movie>(this, "EditMovie", async (obj, update) =>
            {
                var updatedItem = update as Movie;
                this.Movie = updatedItem;
                this.Title = updatedItem.MovieName;
                await DataStore1.UpdateItemAsync(updatedItem);
            });
        }
    }
}
