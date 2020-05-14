﻿using GTBA.ViewModels;
using GTBA.Views.Franchises;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GTBA.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FranchiseListPage : ContentPage
    {
        
        FranchisesViewModel viewModel;

        public FranchiseListPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new FranchisesViewModel();

        }

        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            await DisplayAlert("Item Tapped", "An item was tapped.", "OK");

            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }

        async void AddFranchiseBtn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new NewFranchisePage()));
        }
    }
}
