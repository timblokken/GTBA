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
            DeserializeTags();
            DeleteTagCommand = new Command(tag => ExecuteDeleteTagCommand((string)tag));
        }

        public void Save()
        {
            Movie.Tags = SerializeTags();
            MessagingCenter.Send(this, "EditMovie", Movie);
        }

        public void DeserializeTags()
        {
            string[] tags = Movie.Tags.Split('#');
            foreach (string tag in tags)
            {
                Tags.Add(tag);
            }
        }

    }
}
