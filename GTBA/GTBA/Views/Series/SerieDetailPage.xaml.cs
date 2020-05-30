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
    public partial class SerieDetailPage : ContentPage
    {
        SerieDetailViewModel viewModel;
        public SerieDetailPage(SerieDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }

        async void BackBtn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        async void EditBtn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new EditSeriePage(new EditSerieViewModel(viewModel.Serie))));
        }
    }
}