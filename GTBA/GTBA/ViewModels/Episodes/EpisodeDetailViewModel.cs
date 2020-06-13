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
            DeserializeTags();

            MessagingCenter.Subscribe<EditEpisodeViewModel, Episode>(this, "EditEpisode", async (obj, update) =>
            {
                Episode = update;
                Title = update.EpisodeName;
                DeserializeTags();
                await DataStore.UpdateItemAsync(update);
            });
        }
        public void Delete()
        {
            MessagingCenter.Send(this, "DeleteEpisode", Episode);
        }

        public void DeserializeTags()
        {
            Tags.Clear();
            string[] tags = Episode.Tags.Split('#');
            foreach (string tag in tags)
            {
                Tags.Add(tag);
            }
        }
    }
}
