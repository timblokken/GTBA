using GTBA.Models;
using GTBA.Services.Interfaces;
using GTBA.Views.Series;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace GTBA.ViewModels.Series
{
    public class SerieDetailViewModel : BaseViewModel
    {
        public ISeriesDataStore DataStore => DependencyService.Get<ISeriesDataStore>();
        public Serie Serie { get; set; }
        public SerieDetailViewModel(Serie serie = null)
        {
            Title = serie?.SerieName;
            Serie = serie;

            MessagingCenter.Subscribe<EditSerieViewModel, Serie>(this, "EditSerie", async (obj, update) =>
            {
                Serie = update;
                Title = update.SerieName;
                await DataStore.UpdateItemAsync(update);
            });
        }
    }
}
