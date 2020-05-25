using GTBA.Models;
using GTBA.Services.Interfaces;
using GTBA.ViewModels.Games;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace GTBA.ViewModels
{
    public class GamesViewModel : BaseViewModel
    {
        public IGamesDataStore DataStore => DependencyService.Get<IGamesDataStore>();
        public ObservableCollection<Game> Games { get; set; }
        public Command LoadItemsCommand { get; set; }
        public GamesViewModel(Franchise franchise = null)
        {
            Title = franchise != null ? "Games" : "GTBA";
            Games = new ObservableCollection<Game>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand(franchise));

            MessagingCenter.Subscribe<NewGameViewModel, Game>(this, "AddMovie", async (obj, game) =>
            {
                var newItem = game as Game;
                Games.Add(newItem);
                await DataStore.AddItemAsync(newItem);
            });
        }

        async Task ExecuteLoadItemsCommand(Franchise franchise = null)
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Games.Clear();
                IEnumerable<Game> games;
                if (franchise != null)
                {
                    games = await DataStore.GetItemsByFranhciseAsync(franchise.FranchiseId);
                }
                else
                {
                    games = await DataStore.GetItemsAsync(true);
                }

                foreach (var game in games)
                {
                    Games.Add(game);
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
