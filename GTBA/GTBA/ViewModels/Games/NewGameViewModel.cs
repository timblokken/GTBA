using GTBA.Models;
using GTBA.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace GTBA.ViewModels.Games
{
    public class NewGameViewModel : BaseViewModel
    {

        public IDataStore<Franchise> DataStore => DependencyService.Get<IDataStore<Franchise>>();
        public Game Game { get; set; }
        public ObservableCollection<Franchise> Franchises { get; set; }
        private Franchise selectedFranchise;

        public NewGameViewModel()
        {
            Game = new Game();

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
            Game.FranchiseId = selectedFranchise.FranchiseId;
            MessagingCenter.Send(this, "AddGame", Game);
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
