﻿using GTBA.ViewModels;
using GTBA.Views.Series;
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
    public partial class SeriesListPage : ContentPage
    {
        SeriesViewModel viewModel;

        public SeriesListPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new SeriesViewModel();
        }

        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            await DisplayAlert("Item Tapped", "An item was tapped.", "OK");

            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }

        async void AddSerieBtn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new NewSeriePage()));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Series.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }
    }
}
