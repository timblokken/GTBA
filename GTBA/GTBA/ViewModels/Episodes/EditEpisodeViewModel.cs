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
        }

        public void Save()
        {
            MessagingCenter.Send(this, "EditEpisode", Episode);
        }
    }
}
