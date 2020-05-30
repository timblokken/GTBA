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
    public partial class EditSeriePage : ContentPage
    {
        EditSerieViewModel viewModel;
        public EditSeriePage(EditSerieViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
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