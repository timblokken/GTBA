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
        public IGamesDataStore DataStore => DependencyService.Get<IGamesDataStore>();
        public Game Game { get; set; }

        public GameDetailViewModel(Game game = null)
        {
            Title = game?.GameName;
            Game = game;
            DeserializeTags();

            MessagingCenter.Subscribe<EditGameViewModel, Game>(this, "EditGame", async (obj, update) =>
            {
                Game = update;
                Title = update.GameName;
                DeserializeTags();
                await DataStore.UpdateItemAsync(update);
            });
        }

        public void Delete()
        {
            MessagingCenter.Send(this, "DeleteGame", Game);
        }

        public void DeserializeTags()
        {
            Tags.Clear();
            string[] tags = Game.Tags.Split('#');
            foreach (string tag in tags)
            {
                Tags.Add(tag);
            }
        }
    }
}
