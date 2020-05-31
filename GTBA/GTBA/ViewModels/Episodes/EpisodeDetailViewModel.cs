using GTBA.Models;
using GTBA.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace GTBA.ViewModels.Episodes
{
    public class EpisodeDetailViewModel : BaseViewModel
    {
        public IEpisodeDataStore DataStore => DependencyService.Get<IEpisodeDataStore>();
        public Episode Episode { get; set; }
        public EpisodeDetailViewModel(Episode episode = null)
        {
            Title = episode?.EpisodeName;
            Episode = episode;

            MessagingCenter.Subscribe<EditEpisodeViewModel, Episode>(this, "EditEpisode", async (obj, update) =>
            {
                this.Episode = update;
                this.Title = update.EpisodeName;
                await DataStore.UpdateItemAsync(update);
            });
        }
        public void Delete()
        {
            MessagingCenter.Send(this, "DeleteEpisode", Episode);
        }
    }
}
