using GTBA.Models;
using GTBA.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace GTBA.ViewModels.Movies
{
    public class NewMovieViewModel : BaseViewModel
    {
        public IDataStore<Franchise> DataStore => DependencyService.Get<IDataStore<Franchise>>();
        public Movie Movie { get; set; }
        public ObservableCollection<Franchise> Franchises { get; set; }
        private Franchise selectedFranchise;

        public NewMovieViewModel()
        {
            Movie = new Movie();
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
            Movie.FranchiseId = selectedFranchise.FranchiseId;
            MessagingCenter.Send(this, "AddMovie", Movie);
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
