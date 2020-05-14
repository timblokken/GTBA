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
        public ObservableCollection<string> Franchises { get; set; }

        public FranchisesViewModel()
        {
            Title = "GTBA";

            Franchises = new ObservableCollection<string>
            {
                "franchise 1",
                "franchise 2",
                "franchise 3",
                "franchise 4",
                "franchise 5"
            };

            MessagingCenter.Subscribe<NewFranchisePage, Franchise>(this, "AddFranchise", async (obj, franchise) =>
            {
                var newItem = franchise as Franchise;
                Franchises.Add(newItem.FranchiseName);
                await DataStore1.AddItemAsync(newItem);
            });
        }

    }
}
