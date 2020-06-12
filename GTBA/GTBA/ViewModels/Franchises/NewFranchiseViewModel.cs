using GTBA.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace GTBA.ViewModels.Franchises
{
    public class NewFranchiseViewModel : BaseViewModel
    {
        public Franchise Franchise { get; set; }
        public ObservableCollection<string> Tags { get; set; }
        public NewFranchiseViewModel()
        {
            Franchise = new Franchise();
            Tags = new ObservableCollection<string>();
        }

        public void Save()
        {
            Franchise.Tags = SerializeTags();
            MessagingCenter.Send(this, "AddFranchise", Franchise);
        }

        public void AddTag(string tag)
        {
            Tags.Add(tag);
        }

        public string SerializeTags()
        {
            String str = "";
            for (int i = 0; i < Tags.Count; i++)
            {
                str += Tags[i];
                // Do not append comma at the end of last element
                if (i < Tags.Count - 1)
                {
                    str += "#";
                }
            }
            return str;
        }

    }
}
