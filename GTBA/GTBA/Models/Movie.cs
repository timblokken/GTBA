using System;
using System.Collections.Generic;
using System.Text;

namespace GTBA.Models
{
    public class Movie : BaseModel
    {
        int movieId = -1;
        public int MovieId
        {
            get { return movieId; }
            set { SetProperty(ref movieId, value); }
        }

        string movieName = string.Empty;
        public string MovieName
        {
            get { return movieName; }
            set { SetProperty(ref movieName, value); }
        }

        TimeSpan movieLength = TimeSpan.Zero;
        public TimeSpan MovieLength
        {
            get { return movieLength; }
            set { SetProperty(ref movieLength, value); }
        }

        int franchiseId = -1;
        public int FranchiseId
        {
            get { return franchiseId; }
            set { SetProperty(ref franchiseId, value); }
        }
        public Franchise Franchise { get; set; }
    }
}
