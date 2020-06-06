using GTBA.Models;
using GTBA.ViewModels;
using GTBA.ViewModels.Franchises;
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

            var franchise = (Franchise)e.Item;
            await Navigation.PushAsync(new FranchiseTabbedPage(new FranchiseTabbedViewModel(franchise)));

            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }

        async void AddFranchiseBtn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new NewFranchisePage()));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Franchises.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }

        private async void editMenuItem_Clicked(object sender, EventArgs e)
        {
            MenuItem menuItem = sender as MenuItem;
            var contextItem = (Franchise)menuItem.BindingContext;
            await Navigation.PushModalAsync(new NavigationPage(new EditFranchisePage(new EditFranchiseViewModel(contextItem))));
        }

        private async void detailsMenuItem_Clicked(object sender, EventArgs e)
        {
            MenuItem menuItem = sender as MenuItem;
            var contextItem = (Franchise)menuItem.BindingContext;
            await Navigation.PushModalAsync(new NavigationPage(new FranchiseDetailPage(new FranchiseDetailViewModel(contextItem))));
        }

        private async void DeleteMenuItem_Clicked(object sender, EventArgs e)
        {
            MenuItem menuItem = sender as MenuItem;
            var contextItem = (Franchise)menuItem.BindingContext;
            await viewModel.DeleteFranchise(contextItem);
        }
    }
}