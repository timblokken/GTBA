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
    public partial class NewEpisodePage : ContentPage
    {
        NewEpisodeViewModel viewModel;
        public NewEpisodePage()
        {
            InitializeComponent();

            BindingContext = viewModel = new NewEpisodeViewModel();
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