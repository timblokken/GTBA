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
        public IDataStore<Serie> DataStore => DependencyService.Get<IDataStore<Serie>>();
        public Serie Serie { get; set; }
        public SerieDetailViewModel(Serie serie = null)
        {
            Title = serie?.SerieName;
            Serie = serie;

            MessagingCenter.Subscribe<EditSeriePage, Serie>(this, "EditMovie", async (obj, update) =>
            {
                var updatedItem = update as Serie;
                this.Serie = updatedItem;
                this.Title = updatedItem.SerieName;
                await DataStore.UpdateItemAsync(updatedItem);
            });
        }
    }
}
