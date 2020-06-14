using GTBA.Models;
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
            SortCommand = new Command(async (parameter) => await ExecuteLoadItemsCommand(franchise, (string)parameter));

            MessagingCenter.Subscribe<NewSerieViewModel, Serie>(this, "AddSerie", async (obj, serie) =>
            {
                await DataStore.AddItemAsync(serie);
                await ExecuteLoadItemsCommand(franchise);
            });

            MessagingCenter.Subscribe<SerieDetailViewModel, Serie>(this, "DeleteSerie", async (obj, serie) =>
            {
                await DeleteSerie(serie);
            });
        }

        public async Task DeleteSerie(Serie serie)
        {
            await DataStore.DeleteItemAsync(serie.SerieId);
            await ExecuteLoadItemsCommand(franchise);
        }

        public async Task UpdateSerie(Serie serie)
        {
            await DataStore.UpdateItemAsync(serie);
        }

        async Task ExecuteLoadItemsCommand(Franchise franchise = null, string sorter = null)
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
                    series = await DataStore.GetItemsByFranchiseAsync(franchise.FranchiseId, sorter);
                }
                else
                {
                    series = await DataStore.GetItemsAsync(true, sorter);
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

        public async Task ExecutePerformSearchCommand(string search, Franchise franchise = null, string sorter = null)
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
                    series = await DataStore.GetItemsByTagByFranchiseAsync(search, franchise.FranchiseId, sorter);
                }
                else
                {
                    series = await DataStore.GetItemsByTagsAsync(search, sorter);
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
