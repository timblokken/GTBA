using System;
using System.Collections.Generic;
using System.Text;

namespace GTBA.Models
{
    public class Serie : BaseModel
    {
        //id of the serie
        //Primary Key , auto incremented
        private int serieId;
        public int SerieId
        {
            get { return serieId; }
            set { SetProperty(ref serieId, value); }
        }

        //Name of the movie
        private string serieName = string.Empty;
        public string SerieName
        {
            get { return serieName; }
            set { SetProperty(ref serieName, value); }
        }

        //number of seasons in serie
        private int? seasons;
        public int? Seasons
        {
            get { return seasons; }
            set { SetProperty(ref seasons, value); }
        }

        //number of episodes in serie
        private int? nrOfEpisodes;
        public int? NrOfEpisodes
        {
            get { return nrOfEpisodes; }
            set { SetProperty(ref nrOfEpisodes, value); }
        }

        //have you seen the movie or not
        private bool seen = false;
        public bool Seen
        {
            get { return seen = false; }
            set { SetProperty(ref seen, value); }
        }

        //id of the franchise the serie is in
        //foreign key
        int franchiseId;
        public int FranchiseId
        {
            get { return franchiseId; }
            set { SetProperty(ref franchiseId, value); }
        }
        public Franchise Franchise { get; set; }

        public ICollection<Episode> Episodes { get; set; }
    }
}
