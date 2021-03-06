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
        public IMovieDataStore DataStore => DependencyService.Get<IMovieDataStore>();
        public Movie Movie { get; set; }
        public MovieDetailViewModel(Movie movie = null)
        {
            Title = movie?.MovieName;
            Movie = movie;
            DeserializeTags();

            MessagingCenter.Subscribe<EditMovieViewModel, Movie>(this, "EditMovie", async (obj, update) =>
            {
                Movie = update;
                Title = update.MovieName;
                DeserializeTags();
                await DataStore.UpdateItemAsync(update);
            });
        }

        public void Delete()
        {
            MessagingCenter.Send(this, "DeleteMovie", Movie);
        }

        public void DeserializeTags()
        {
            Tags.Clear();
            string[] tags = Movie.Tags.Split('#');
            foreach (string tag in tags)
            {
                Tags.Add(tag);
            }
        }
    }
}
