﻿using GTBA.Models;
using GTBA.ViewModels;
using GTBA.ViewModels.Episodes;
using GTBA.ViewModels.Series;
using GTBA.Views.Episodes;
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

        public SeriesListPage(SeriesViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }

        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            var serie = (Serie)e.Item;
            await Navigation.PushAsync(new EpisodesListPage(new EpisodesViewModel(serie)));

            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }

        async void AddSerieBtn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new NewSeriePage(viewModel.franchise)));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Series.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }

        private async void editMenuItem_Clicked(object sender, EventArgs e)
        {
            MenuItem menuItem = sender as MenuItem;
            var contextItem = (Serie)menuItem.BindingContext;
            await Navigation.PushModalAsync(new NavigationPage(new EditSeriePage(new EditSerieViewModel(contextItem))));
        }

        private async void detailsMenuItem_Clicked(object sender, EventArgs e)
        {
            MenuItem menuItem = sender as MenuItem;
            var contextItem = (Serie)menuItem.BindingContext;
            await Navigation.PushModalAsync(new NavigationPage(new SerieDetailPage(new SerieDetailViewModel(contextItem))));
        }

        private async void DeleteMenuItem_Clicked(object sender, EventArgs e)
        {
            MenuItem menuItem = sender as MenuItem;
            var contextItem = (Serie)menuItem.BindingContext;
            await viewModel.DeleteSerie(contextItem);
        }

        private async void seenMenuItem_Clicked(object sender, EventArgs e)
        {
            MenuItem menuItem = sender as MenuItem;
            var contextItem = (Serie)menuItem.BindingContext;
            contextItem.Seen = !contextItem.Seen;
            await viewModel.UpdateSerie(contextItem);
        }

        private void SearchToolbarItem_Clicked(object sender, EventArgs e)
        {
            tagSearchBar.Text = "";
            tagSearchBar.IsVisible = !tagSearchBar.IsVisible;
        }

        private async void tagSearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            await viewModel.ExecutePerformSearchCommand(e.NewTextValue, viewModel.franchise);
        }
    }
}
