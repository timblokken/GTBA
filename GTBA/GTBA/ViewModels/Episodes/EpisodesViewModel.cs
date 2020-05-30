using GTBA.Models;
using GTBA.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace GTBA.ViewModels.Episodes
{
    public class EpisodesViewModel : BaseViewModel
    {
        public IEpisodeDataStore DataStore => DependencyService.Get<IEpisodeDataStore>();
        public ObservableCollection<Episode> Episodes { get; set; }
        public Command LoadItemsCommand { get; set; }
        public EpisodesViewModel(Serie serie = null)
        {
            Title = serie != null ? serie.SerieName : "Episodes";
            Episodes = new ObservableCollection<Episode>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand(serie));

            MessagingCenter.Subscribe<NewEpisodeViewModel, Episode>(this, "AddEpisode", async (obj, episode) =>
            {
                Episodes.Add(episode);
                await DataStore.AddItemAsync(episode);
                await ExecuteLoadItemsCommand();
            });
        }

        async Task ExecuteLoadItemsCommand(Serie serie = null)
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Episodes.Clear();
                IEnumerable<Episode> episodes;
                if (serie != null)
                {
                    episodes = await DataStore.GetItemsBySerieAsync(serie.SerieId);
                }
                else
                {
                    episodes = await DataStore.GetItemsAsync(true);
                }

                foreach (var episode in episodes)
                {
                    Episodes.Add(episode);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
