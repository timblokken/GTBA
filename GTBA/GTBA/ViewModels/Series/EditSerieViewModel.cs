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
            DeserializeTags();
            DeleteTagCommand = new Command(tag => ExecuteDeleteTagCommand((string)tag));
        }

        public void Save()
        {
            Serie.Tags = SerializeTags();
            MessagingCenter.Send(this, "EditSerie", Serie);
        }

        public void DeserializeTags()
        {
            string[] tags = Serie.Tags.Split('#');
            foreach (string tag in tags)
            {
                Tags.Add(tag);
            }
        }
    }
}
