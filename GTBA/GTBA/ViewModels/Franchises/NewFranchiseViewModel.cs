using GTBA.Models;
using System;
using System.Collections.Generic;
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
            MessagingCenter.Send(this, "AddFranchise", Franchise);
        }

    }
}
