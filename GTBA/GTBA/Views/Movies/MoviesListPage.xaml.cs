using GTBA.Models;
using GTBA.ViewModels;
using GTBA.ViewModels.Movies;
using GTBA.Views.Movies;
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
    public partial class MoviesListPage : ContentPage
    {
        MoviesViewModel viewModel;

        public MoviesListPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new MoviesViewModel();
        }

        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            var movie = (Movie)e.Item;
            await Navigation.PushModalAsync(new NavigationPage(new MovieDetailPage(new MovieDetailViewModel(movie))));

            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }

        private async void AddMovieBtn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new NewMoviePage()));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Movies.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }
    }
}
