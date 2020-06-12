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
        public NewFranchiseViewModel()
        {
            Franchise = new Franchise();
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

        

    }
}
