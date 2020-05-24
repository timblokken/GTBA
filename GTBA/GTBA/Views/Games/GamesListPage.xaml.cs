using GTBA.ViewModels;
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

        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            await DisplayAlert("Item Tapped", "An item was tapped.", "OK");

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
