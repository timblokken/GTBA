﻿using GTBA.Models;
using GTBA.Services.Interfaces;
using GTBA.ViewModels.Series;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace GTBA.ViewModels
{
    public class SeriesViewModel : BaseViewModel
    {
        public ISeriesDataStore DataStore => DependencyService.Get<ISeriesDataStore>();
        public ObservableCollection<Serie> Series { get; set; }
        public Command LoadItemsCommand { get; set; }
        public Franchise franchise;

        public SeriesViewModel(Franchise franchise = null)
        {
            Title = "Series";
            this.franchise = franchise;
            Series = new ObservableCollection<Serie>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand(franchise));

            MessagingCenter.Subscribe<NewSerieViewModel, Serie>(this, "AddSerie", async (obj, serie) =>
            {
                Series.Add(serie);
                await DataStore.AddItemAsync(serie);
                await ExecuteLoadItemsCommand(franchise);
            });

            MessagingCenter.Subscribe<SerieDetailViewModel, Serie>(this, "DeleteSerie", async (obj, serie) =>
            {
                Series.Remove(serie);
                await DataStore.DeleteItemAsync(serie.SerieId);
                await ExecuteLoadItemsCommand(franchise);
            });
        }

        public async Task DeleteSerie(Serie serie)
        {
            Series.Remove(serie);
            await DataStore.DeleteItemAsync(serie.SerieId);
            await ExecuteLoadItemsCommand(franchise);
        }

        public async Task UpdateSerie(Serie serie)
        {
            await DataStore.UpdateItemAsync(serie);
        }

        async Task ExecuteLoadItemsCommand(Franchise franchise = null)
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Series.Clear();
                IEnumerable<Serie> series;
                if (franchise != null)
                {
                    series = await DataStore.GetItemsByFranchiseAsync(franchise.FranchiseId);
                }
                else
                {
                    series = await DataStore.GetItemsAsync(true);
                }
                foreach (var serie in series)
                {
                    Series.Add(serie);
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
