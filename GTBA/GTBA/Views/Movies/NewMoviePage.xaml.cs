using GTBA.Models;
using GTBA.Services.Interfaces;
using GTBA.ViewModels.Movies;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GTBA.Views.Movies
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewMoviePage : ContentPage
    {

        NewMovieViewModel viewModel;
        
        public NewMoviePage(Franchise franchise = null)
        {
            InitializeComponent();

            BindingContext = viewModel = new NewMovieViewModel(franchise);

            if (franchise != null)
            {
                FranchisePicker.IsEnabled = false;
            }
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            viewModel.Save();
            await Navigation.PopModalAsync();
        }

        async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}