using GTBA.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace GTBA.ViewModels.Games
{
    public class EditGameViewModel : BaseViewModel
    {
        public Game Game { get; set; }

        public EditGameViewModel(Game game)
        {
            Title = game?.GameName;
            Game = game;
            DeserializeTags();
            DeleteTagCommand = new Command(tag => ExecuteDeleteTagCommand((string)tag));
        }

        public void Save()
        {
            Game.Tags = SerializeTags();
            MessagingCenter.Send(this, "EditGame", Game);
        }

        public void AddTag(string tag)
        {
            Tags.Add(tag);
        }

        public void DeserializeTags()
        {
            string[] tags = Game.Tags.Split('#');
            foreach (string tag in tags)
            {
                Tags.Add(tag);
            }
        }
    }
}
