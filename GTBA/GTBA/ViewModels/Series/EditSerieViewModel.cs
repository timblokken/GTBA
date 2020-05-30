using GTBA.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace GTBA.ViewModels.Series
{
    public class EditSerieViewModel : BaseViewModel
    {
        public Serie Serie { get; set; }
        public EditSerieViewModel(Serie serie)
        {
            Title = serie?.SerieName;
            Serie = serie;
        }

        public void Save()
        {
            MessagingCenter.Send(this, "EditSerie", Serie);
        }
    }
}
