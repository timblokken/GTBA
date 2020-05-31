using GTBA.Models;
using GTBA.Services;
using GTBA.Services.Interfaces;
using GTBA.Views.Franchises;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace GTBA.ViewModels.Franchises
{
    public class FranchiseDetailViewModel : BaseViewModel
    {
        public IFranchisesDataStore DataStore => DependencyService.Get<IFranchisesDataStore>();
        public Franchise Franchise { get; set; }

        public FranchiseDetailViewModel(Franchise franchise = null)
        {
            Title = franchise?.FranchiseName;
            Franchise = franchise;

            MessagingCenter.Subscribe<EditFranchiseViewModel, Franchise>(this, "EditFranchise", async (obj, update) =>
            {
                Franchise = update;
                Title = update.FranchiseName;
                await DataStore.UpdateItemAsync(update);
            });
        }

        public void Delete()
        {
            MessagingCenter.Send(this, "DeleteFranchise", Franchise);
        }


    }
}
