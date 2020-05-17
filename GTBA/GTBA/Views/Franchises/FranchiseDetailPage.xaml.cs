using GTBA.Models;
using GTBA.ViewModels.Franchises;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GTBA.Views.Franchises
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FranchiseDetailPage : ContentPage
    {
        FranchiseDetailViewModel viewModel;
        public FranchiseDetailPage(FranchiseDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }

        public FranchiseDetailPage()
        {
            InitializeComponent();

            var franchise = new Franchise
            {
                FranchiseName = "Item 1",
                
            };

            viewModel = new FranchiseDetailViewModel(franchise);
            BindingContext = viewModel;
        }

        async void BackBtn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        async void EditBtn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new EditFranchisePage(viewModel)));
        }
    }
}