using GTBA.ViewModels.Movies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GTBA.Views.Movies
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditMoviePage : ContentPage
    {
        MovieDetailViewModel viewModel;
        public EditMoviePage(MovieDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "EditMovie", viewModel.Movie);
            await Navigation.PopModalAsync();
        }

        async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}