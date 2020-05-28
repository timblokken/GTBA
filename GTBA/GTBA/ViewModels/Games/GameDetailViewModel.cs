using GTBA.Models;
using GTBA.Services.Interfaces;
using GTBA.Views.Games;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace GTBA.ViewModels.Games
{
    public class GameDetailViewModel : BaseViewModel
    {
        public IDataStore<Game> DataStore => DependencyService.Get<IDataStore<Game>>();
        public Game Game { get; set; }

        public GameDetailViewModel(Game game = null)
        {
            Title = game?.GameName;
            Game = game;

            MessagingCenter.Subscribe<EditGamePage, Game>(this, "EditGame", async (obj, update) =>
            {
                this.Game = update;
                this.Title = update.GameName;
                await DataStore.UpdateItemAsync(update);
            });
        }
    }
}
