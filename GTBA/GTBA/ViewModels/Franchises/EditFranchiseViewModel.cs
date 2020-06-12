using GTBA.Models;
using GTBA.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace GTBA.ViewModels.Franchises
{
    public class EditFranchiseViewModel : BaseViewModel
    {
        public Franchise Franchise { get; set; }
        public EditFranchiseViewModel(Franchise franchise)
        {
            Franchise = franchise;
            Title = franchise?.FranchiseName;
            DeserializeTags();
        }

        public void Save()
        {
            Franchise.Tags = SerializeTags();
            MessagingCenter.Send(this, "EditFranchise", Franchise);
        }

        public void AddTag(string tag)
        {
            Tags.Add(tag);
        }

        public void DeserializeTags()
        {
            string[] tags = Franchise.Tags.Split('#');
            foreach (string tag in tags)
            {
                Tags.Add(tag);
            }
        }
    }
}
