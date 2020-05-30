using GTBA.Models;
using GTBA.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace GTBA.ViewModels.Episodes
{
    public class NewEpisodeViewModel : BaseViewModel
    {
        public ISeriesDataStore DataStore => DependencyService.Get<ISeriesDataStore>();
        public Episode Episode { get; set; }
        public ObservableCollection<Serie> Series { get; set; }
        private Serie selectedSerie;

        public NewEpisodeViewModel()
        {
            Episode = new Episode();
            Series = new ObservableCollection<Serie>();
            GetSeries();
        }

        public Serie SelectedSerie
        {
            get { return selectedSerie; }
            set { SetProperty(ref selectedSerie, value); }
        }

        public void Save()
        {
            Episode.SerieId = selectedSerie.SerieId;
            MessagingCenter.Send(this, "AddEpisode", Episode);
        }
        async void GetSeries()
        {
            Series.Clear();
            var series = await DataStore.GetItemsAsync(true);
            foreach (Serie serie in series)
            {
                Series.Add(serie);
            }
        }
    }
}
