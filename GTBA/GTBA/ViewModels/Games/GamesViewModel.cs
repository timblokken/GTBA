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
        public IDataStore<Game> DataStore => DependencyService.Get<IDataStore<Game>>();
        public ObservableCollection<Game> Games { get; set; }
        public Command LoadItemsCommand { get; set; }
        public GamesViewModel()
        {
            Title = "GTBA";
            Games = new ObservableCollection<Game>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            MessagingCenter.Subscribe<NewGameViewModel, Game>(this, "AddMovie", async (obj, game) =>
            {
                var newItem = game as Game;
                Games.Add(newItem);
                await DataStore.AddItemAsync(newItem);
            });
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Games.Clear();
                var movies = await DataStore.GetItemsAsync(true);
                foreach (var movie in movies)
                {
                    Games.Add(movie);
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
