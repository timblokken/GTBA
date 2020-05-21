using GTBA.Models;
using GTBA.Services.Interfaces;
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
        public IDataStore<Serie> DataStore => DependencyService.Get<IDataStore<Serie>>();
        public ObservableCollection<Serie> Series { get; set; }
        public Command LoadItemsCommand { get; set; }
        public SeriesViewModel()
        {
            Title = "GTBA";
            Series = new ObservableCollection<Serie>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            //MessagingCenter.Subscribe<NewSerieViewModel, Serie>(this, "AddMovie", async (obj, serie) =>
            //{
            //    var newItem = serie as Serie;
            //    Series.Add(newItem);
            //    await DataStore.AddItemAsync(newItem);
            //});
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Series.Clear();
                var movies = await DataStore.GetItemsAsync(true);
                foreach (var movie in movies)
                {
                    Series.Add(movie);
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
