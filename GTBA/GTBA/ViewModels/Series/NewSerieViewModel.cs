using GTBA.Models;
using GTBA.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace GTBA.ViewModels.Series
{
    public class NewSerieViewModel : BaseViewModel
    {

        public IDataStore<Franchise> DataStore => DependencyService.Get<IDataStore<Franchise>>();
        public Serie Serie { get; set; }
        public ObservableCollection<Franchise> Franchises { get; set; }
        private Franchise selectedFranchise;

        public NewSerieViewModel()
        {
            Serie = new Serie();
            Franchises = new ObservableCollection<Franchise>();

            GetFranchises();
        }

        public Franchise SelectedFranchise
        {
            get { return selectedFranchise; }
            set { SetProperty(ref selectedFranchise, value); }
        }

        public void Save()
        {
            Serie.FranchiseId = selectedFranchise.FranchiseId;
            MessagingCenter.Send(this, "AddSerie", Serie);
        }
        async void GetFranchises()
        {
            Franchises.Clear();
            var franchises = await DataStore.GetItemsAsync(true);
            foreach (Franchise franchise in franchises)
            {
                Franchises.Add(franchise);
            }
        }
    }
}
