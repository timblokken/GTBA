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

        public IFranchisesDataStore DataStore => DependencyService.Get<IFranchisesDataStore>();
        public Serie Serie { get; set; }
        public ObservableCollection<Franchise> Franchises { get; set; }
        private Franchise selectedFranchise;

        public NewSerieViewModel(Franchise franchise = null)
        {
            Serie = new Serie();
            Franchises = new ObservableCollection<Franchise>();

            if (franchise != null)
            {
                SelectedFranchise = franchise;
            }

            GetFranchises();
            DeleteTagCommand = new Command(tag => ExecuteDeleteTagCommand((string)tag));
        }

        public Franchise SelectedFranchise
        {
            get { return selectedFranchise; }
            set { SetProperty(ref selectedFranchise, value); }
        }

        public void Save()
        {
            Serie.FranchiseId = selectedFranchise.FranchiseId;
            Serie.Tags = SerializeTags();
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
