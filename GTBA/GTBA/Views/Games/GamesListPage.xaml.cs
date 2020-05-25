﻿using GTBA.Models;
using GTBA.ViewModels;
using GTBA.ViewModels.Games;
using GTBA.Views.Games;
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
    public partial class GamesListPage : ContentPage
    {
        GamesViewModel viewModel;

        public GamesListPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new GamesViewModel();
        }

        public GamesListPage(GamesViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }

        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            var game = (Game)e.Item;
            await Navigation.PushModalAsync(new NavigationPage(new GameDetailPage(new GameDetailViewModel(game))));

            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }

        async void AddGameBtn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new NewGamePage()));
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Games.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }
    }
}
