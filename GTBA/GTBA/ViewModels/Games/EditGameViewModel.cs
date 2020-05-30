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
        }

        public void Save()
        {
            MessagingCenter.Send(this, "EditGame", Game);
        }
    }
}
