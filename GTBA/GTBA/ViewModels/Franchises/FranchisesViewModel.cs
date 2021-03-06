﻿using GTBA.Models;
using GTBA.Services;
using GTBA.Services.Interfaces;
using GTBA.ViewModels.Franchises;
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

        public IFranchisesDataStore DataStore => DependencyService.Get<IFranchisesDataStore>();
        public ObservableCollection<Franchise> Franchises { get; set; }
        public Command LoadItemsCommand { get; set; }
        public Command PerformSearch { get; set; }

        public FranchisesViewModel()
        {
            Title = "GTBA";
            Franchises = new ObservableCollection<Franchise>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
            SortCommand = new Command(async (parameter) => await ExecuteLoadItemsCommand((string)parameter));
            PerformSearch = new Command(async (search) => await ExecutePerformSearchCommand((string)search));

            MessagingCenter.Subscribe<NewFranchiseViewModel, Franchise>(this, "AddFranchise", async (obj, franchise) =>
            {
                Franchises.Add(franchise);
                await DataStore.AddItemAsync(franchise);
            });

            MessagingCenter.Subscribe<FranchiseDetailViewModel, Franchise>(this, "DeleteFranchise", async (obj, franchise) =>
            {
                await DeleteFranchise(franchise);
            });
        }

        public async Task DeleteFranchise(Franchise franchise)
        {
            Franchises.Remove(franchise);
            await DataStore.DeleteItemAsync(franchise.FranchiseId);
        }

        async Task ExecuteLoadItemsCommand(string sorter = null)
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Franchises.Clear();
                var franchises = await DataStore.GetItemsAsync(true,sorter);
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
        public async Task ExecutePerformSearchCommand(string search, string sorter = null)
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Franchises.Clear();
                var franchises = await DataStore.GetItemsByTagsAsync(search, sorter);
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
