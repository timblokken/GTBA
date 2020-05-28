using System;
using System.Collections.Generic;
using System.Text;

namespace GTBA.Models
{
    public class Movie : BaseModel
    {
        //id of the movie
        //Primary Key, auto incremented
        private int movieId;
        public int MovieId
        {
            get { return movieId; }
            set { SetProperty(ref movieId, value); }
        }

        //Name of the movie
        private string movieName = string.Empty;
        public string MovieName
        {
            get { return movieName; }
            set { SetProperty(ref movieName, value); }
        }

        //Length of the movie in minutes
        private int? movieLength;
        public int? MovieLength
        {
            get { return movieLength; }
            set { SetProperty(ref movieLength, value); }
        }

        //have you seen the movie or not
        private bool seen = false;
        public bool Seen
        {
            get { return seen = false; }
            set { SetProperty(ref seen, value); }
        }

        //id of the franchise the movie is in
        //foreign key
        private int franchiseId;
        public int FranchiseId
        {
            get { return franchiseId; }
            set { SetProperty(ref franchiseId, value); }
        }
        public Franchise Franchise { get; set; }
    }
}
