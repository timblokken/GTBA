using GTBA.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace GTBA.ViewModels.Episodes
{
    public class EditEpisodeViewModel : BaseViewModel
    {
        public Episode Episode { get; set; }
        public EditEpisodeViewModel(Episode episode = null)
        {
            Title = episode?.EpisodeName;
            Episode = episode;
            DeserializeTags();
            DeleteTagCommand = new Command(tag => ExecuteDeleteTagCommand((string)tag));
        }

        public void Save()
        {
            Episode.Tags = SerializeTags();
            MessagingCenter.Send(this, "EditEpisode", Episode);
        }

        public void DeserializeTags()
        {
            string[] tags = Episode.Tags.Split('#');
            foreach (string tag in tags)
            {
                Tags.Add(tag);
            }
        }
    }
}
