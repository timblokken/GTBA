using System;
using System.Collections.Generic;
using System.Text;

namespace GTBA.Models
{
    public class Episode : BaseModel
    {
        int episodeId = -1;
        public int EpisodeId
        {
            get { return episodeId; }
            set { SetProperty(ref episodeId, value); }
        }

        int episodeNr = -1;
        public int EpisodeNr
        {
            get { return episodeNr; }
            set { SetProperty(ref episodeNr, value); }
        }

        string episodeName = string.Empty;
        public string EpisodeName
        {
            get { return episodeName; }
            set { SetProperty(ref episodeName, value); }
        }

        TimeSpan episodeLength = TimeSpan.Zero;
        public TimeSpan EpisodeLength
        {
            get { return episodeLength; }
            set { SetProperty(ref episodeLength, value); }
        }

        int serieId = -1;
        public int SerieId
        {
            get { return serieId; }
            set { SetProperty(ref serieId, value); }
        }
        public Serie Serie { get; set; }
    }
}
