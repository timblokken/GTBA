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
        public Franchise franchise;
        public GamesViewModel(Franchise franchise = null)
        {
            Title = "Games";
            this.franchise = franchise;
            Games = new ObservableCollection<Game>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand(franchise));
            SortCommand = new Command(async (parameter) => await ExecuteLoadItemsCommand(franchise, (string)parameter));

            MessagingCenter.Subscribe<NewGameViewModel, Game>(this, "AddGame", async (obj, game) =>
            {
                Games.Add(game);
                await DataStore.AddItemAsync(game);
                await ExecuteLoadItemsCommand(franchise);
            });

            MessagingCenter.Subscribe<GameDetailViewModel, Game>(this, "DeleteGame", async (obj, game) =>
            {
                await DeleteGame(game);
            });
        }

        public async Task DeleteGame(Game game)
        {
            Games.Remove(game);
            await DataStore.DeleteItemAsync(game.GameId);
            await ExecuteLoadItemsCommand(franchise);
        }

        async Task ExecuteLoadItemsCommand(Franchise franchise = null, string sorter = null)
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
                    games = await DataStore.GetItemsByFranchiseAsync(franchise.FranchiseId, sorter);
                }
                else
                {
                    games = await DataStore.GetItemsAsync(true, sorter);
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

        public async Task ExecutePerformSearchCommand(string search, Franchise franchise = null, string sorter = null)
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
                    games = await DataStore.GetItemsByTagByFranchiseAsync(search, franchise.FranchiseId, sorter);
                }
                else
                {
                    games = await DataStore.GetItemsByTagsAsync(search, sorter);
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
