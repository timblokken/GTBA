using System;
using System.Collections.Generic;
using System.Text;

namespace GTBA.Models
{
    public class Episode
    {
        public int EpisodeId { get; set; }
        public int EpisodeNr { get; set; }
        public string EpisodeName { get; set; }
        public TimeSpan EpisodeLength { get; set; }

        public int SerieId { get; set; }
        public Serie Serie { get; set; }
    }
}
