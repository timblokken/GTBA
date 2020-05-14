using GTBA.Models;
using GTBA.Services;
using GTBA.Views.Franchises;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace GTBA.ViewModels.Franchises
{
    public class FranchiseDetailViewModel : BaseViewModel
    {
        public IDataStore<Franchise> DataStore1 => DependencyService.Get<IDataStore<Franchise>>();
        public Franchise Franchise { get; set; }

        public FranchiseDetailViewModel(Franchise franchise = null)
        {
            Title = franchise?.FranchiseName;
            Franchise = franchise;

           
        }


    }
}
