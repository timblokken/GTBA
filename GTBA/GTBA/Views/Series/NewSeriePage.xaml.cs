using GTBA.Models;
using GTBA.ViewModels.Series;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GTBA.Views.Series
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewSeriePage : ContentPage
    {
        NewSerieViewModel viewModel;

        public NewSeriePage(Franchise franchise = null)
        {
            InitializeComponent();

            BindingContext = viewModel = new NewSerieViewModel(franchise);

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