using GTBA.Models;
using GTBA.Services;
using GTBA.Services.Interfaces;
using GTBA.Views.Franchises;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace GTBA.ViewModels
{
    public class FranchisesViewModel : BaseViewModel
    {

        public IDataStore<Franchise> DataStore1 => DependencyService.Get<IDataStore<Franchise>>();
        public ObservableCollection<Franchise> Franchises { get; set; }
        public Command LoadItemsCommand { get; set; }

        public FranchisesViewModel()
        {
            Title = "GTBA";
            Franchises = new ObservableCollection<Franchise>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            MessagingCenter.Subscribe<NewFranchisePage, Franchise>(this, "AddFranchise", async (obj, franchise) =>
            {
                var newItem = franchise as Franchise;
                Franchises.Add(newItem);
                await DataStore1.AddItemAsync(newItem);
            });
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Franchises.Clear();
                var franchises = await DataStore1.GetItemsAsync(true);
                foreach (var franchise in franchises)
                {
                    Franchises.Add(franchise);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

    }
}
