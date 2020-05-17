using GTBA.Models;
using GTBA.Services;
using GTBA.Views.Franchises;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace GTBA.ViewModels
{
    public class FranchisesViewModel : BaseViewModel
    {

        public IDataStore<Franchise> DataStore1 => DependencyService.Get<IDataStore<Franchise>>();
        public ObservableCollection<Franchise> Franchises { get; set; }

        public FranchisesViewModel()
        {
            Title = "GTBA";

            Franchises = new ObservableCollection<Franchise>
            {
                new Franchise { FranchiseId = 1, FranchiseName = "franchise 1"},
                new Franchise { FranchiseId = 2, FranchiseName = "franchise 2"},
                new Franchise { FranchiseId = 3, FranchiseName = "franchise 3"},
                new Franchise { FranchiseId = 4, FranchiseName = "franchise 4"},
                new Franchise { FranchiseId = 5, FranchiseName = "franchise 5"},
            };

            MessagingCenter.Subscribe<NewFranchisePage, Franchise>(this, "AddFranchise", async (obj, franchise) =>
            {
                var newItem = franchise as Franchise;
                Franchises.Add(newItem);
                await DataStore1.AddItemAsync(newItem);
            });
        }

    }
}
