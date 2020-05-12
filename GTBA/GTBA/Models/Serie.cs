using System;
using System.Collections.Generic;
using System.Text;

namespace GTBA.Models
{
    public class Serie
    {
        public int SerieId { get; set; }
        public string SerieName { get; set; }

        public int FranchiseId { get; set; }
        public Franchise Franchise { get; set; }
    }
}
