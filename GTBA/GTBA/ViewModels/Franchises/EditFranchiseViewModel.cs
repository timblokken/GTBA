using GTBA.Models;
using GTBA.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace GTBA.ViewModels.Franchises
{
    public class EditFranchiseViewModel : BaseViewModel
    {
        public IFranchisesDataStore DataStore => DependencyService.Get<IFranchisesDataStore>();
        public Franchise Franchise { get; set; }
        public EditFranchiseViewModel(Franchise franchise)
        {
            Franchise = franchise;
            Title = franchise?.FranchiseName;
        }

        public void Save()
        {
            MessagingCenter.Send(this, "EditFranchise", Franchise);
        }




    }
}
