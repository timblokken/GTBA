using System;
using System.Collections.Generic;
using System.Text;

namespace GTBA.Models
{
    public class Episode : BaseModel
    {
        int episodeId;
        public int EpisodeId
        {
            get { return episodeId; }
            set { SetProperty(ref episodeId, value); }
        }

        int episodeNr;
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

        int episodeLength;
        public int EpisodeLength
        {
            get { return episodeLength; }
            set { SetProperty(ref episodeLength, value); }
        }

        int serieId;
        public int SerieId
        {
            get { return serieId; }
            set { SetProperty(ref serieId, value); }
        }
        public Serie Serie { get; set; }
    }
}
