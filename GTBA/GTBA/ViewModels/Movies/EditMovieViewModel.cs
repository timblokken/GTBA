using GTBA.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace GTBA.ViewModels.Movies
{
    public class EditMovieViewModel : BaseViewModel
    {
        public Movie Movie { get; set; }
        public EditMovieViewModel(Movie movie)
        {
            Title = movie?.MovieName;
            Movie = movie;
        }

        public void Save()
        {
            MessagingCenter.Send(this, "EditMovie", Movie);
        }

    }
}
