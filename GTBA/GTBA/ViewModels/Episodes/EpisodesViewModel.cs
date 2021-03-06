﻿using GTBA.Models;
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
        public Serie serie; 
        public EpisodesViewModel(Serie serie = null)
        {
            Title = serie != null ? serie.SerieName : "Episodes";
            this.serie = serie;
            Episodes = new ObservableCollection<Episode>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand(serie));
            SortCommand = new Command(async (parameter) => await ExecuteLoadItemsCommand(serie, (string)parameter));

            MessagingCenter.Subscribe<NewEpisodeViewModel, Episode>(this, "AddEpisode", async (obj, episode) =>
            {
                await DataStore.AddItemAsync(episode);
                await ExecuteLoadItemsCommand(serie);
            });

            MessagingCenter.Subscribe<EpisodeDetailViewModel, Episode>(this, "DeleteEpisode", async (obj, episode) =>
            {
                await DeleteEpisode(episode);
            });
        }

        public async Task DeleteEpisode(Episode episode)
        {
            await DataStore.DeleteItemAsync(episode.EpisodeId);
            await ExecuteLoadItemsCommand(serie);
        }

        public async Task UpdateEpisode(Episode episode)
        {
            await DataStore.UpdateItemAsync(episode);
        }

        async Task ExecuteLoadItemsCommand(Serie serie = null, string sorter = null)
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
                    episodes = await DataStore.GetItemsBySerieAsync(serie.SerieId, sorter);
                }
                else
                {
                    episodes = await DataStore.GetItemsAsync(true, sorter);
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

        public async Task ExecutePerformSearchCommand(string search, Serie serie = null, string sorter = null)
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
                    episodes = await DataStore.GetItemsByTagBySerieAsync(search, serie.SerieId, sorter);
                }
                else
                {
                    episodes = await DataStore.GetItemsByTagsAsync(search, sorter);
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
