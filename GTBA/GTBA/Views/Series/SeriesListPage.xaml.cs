using GTBA.Models;
using GTBA.ViewModels;
using GTBA.ViewModels.Series;
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
            await Navigation.PushModalAsync(new NavigationPage(new SerieDetailPage(new SerieDetailViewModel(serie))));

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
