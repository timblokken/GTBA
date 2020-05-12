using System;
using System.Collections.Generic;
using System.Text;

namespace GTBA.Models
{
    public class Franchise
    {
        public int FranchiseId { get; set; }
        public string FranchiseName { get; set; }

        public ICollection<Movie> Movies { get; set; }
    }
}
