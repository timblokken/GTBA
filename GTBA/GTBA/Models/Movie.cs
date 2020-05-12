using System;
using System.Collections.Generic;
using System.Text;

namespace GTBA.Models
{
    public class Movie
    {
        public int MovieId { get; set; }
        public string MovieName { get; set; }
        public TimeSpan MovieLenth { get; set; }

        public int FranchiseId { get; set; }
        public Franchise Franchise { get; set; }
    }
}
