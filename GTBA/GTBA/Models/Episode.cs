using System;
using System.Collections.Generic;
using System.Text;

namespace GTBA.Models
{
    public class Episode : BaseModel
    {
        //id of the episode
        //Primary Key , auto incremented
        private int episodeId;
        public int EpisodeId
        {
            get { return episodeId; }
            set { SetProperty(ref episodeId, value); }
        }

        //number of season this episode is in
        private int? season;
        public int? Season
        {
            get { return season; }
            set { SetProperty(ref season, value); }
        }

        //number of episode in its season or in serie, to preference of user
        int? episodeNr;
        public int? EpisodeNr
        {
            get { return episodeNr; }
            set { SetProperty(ref episodeNr, value); }
        }

        //name of episode
        private string episodeName = string.Empty;
        public string EpisodeName
        {
            get { return episodeName; }
            set { SetProperty(ref episodeName, value); }
        }

        //have you seen the episode or not
        private bool seen = false;
        public bool Seen
        {
            get { return seen; }
            set { SetProperty(ref seen, value); }
        }

        private string description = string.Empty;
        public string Description
        {
            get { return description; }
            set { SetProperty(ref description, value); }
        }

        //id of the serie the episode is in
        //acts as foreign key
        private int serieId;
        public int SerieId
        {
            get { return serieId; }
            set { SetProperty(ref serieId, value); }
        }
        public Serie Serie { get; set; }
    }
}
