using GTBA.Models;
using GTBA.ViewModels.Episodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GTBA.Views.Episodes
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EpisodesListPage : ContentPage
    {
        EpisodesViewModel viewModel;
        public EpisodesListPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new EpisodesViewModel();
        }

        public EpisodesListPage(EpisodesViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }

        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            var episode = (Episode)e.Item;
            await Navigation.PushModalAsync(new NavigationPage(new EpisodeDetailPage(new EpisodeDetailViewModel(episode))));

            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }

        async void AddEpiBtn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new NewEpisodePage(viewModel.serie)));
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Episodes.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }

        private async void editMenuItem_Clicked(object sender, EventArgs e)
        {
            MenuItem menuItem = sender as MenuItem;
            var contextItem = (Episode)menuItem.BindingContext;
            await Navigation.PushModalAsync(new NavigationPage(new EditEpisodePage(new EditEpisodeViewModel(contextItem))));
        }

        private async void detailsMenuItem_Clicked(object sender, EventArgs e)
        {
            MenuItem menuItem = sender as MenuItem;
            var contextItem = (Episode)menuItem.BindingContext;
            await Navigation.PushModalAsync(new NavigationPage(new EpisodeDetailPage(new EpisodeDetailViewModel(contextItem))));
        }

        private async void DeleteMenuItem_Clicked(object sender, EventArgs e)
        {
            MenuItem menuItem = sender as MenuItem;
            var contextItem = (Episode)menuItem.BindingContext;
            await viewModel.DeleteEpisode(contextItem);
        }

        private async void seenMenuItem_Clicked(object sender, EventArgs e)
        {
            MenuItem menuItem = sender as MenuItem;
            var contextItem = (Episode)menuItem.BindingContext;
            contextItem.Seen = !contextItem.Seen;
            await viewModel.UpdateEpisode(contextItem);
        }

        private void SearchToolbarItem_Clicked(object sender, EventArgs e)
        {
            tagSearchBar.Text = "";
            tagSearchBar.IsVisible = !tagSearchBar.IsVisible;
        }

        private async void tagSearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            await viewModel.ExecutePerformSearchCommand(e.NewTextValue, viewModel.serie);
        }
    }
}