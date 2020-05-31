using GTBA.Models;
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
    public partial class EpisodeDetailPage : ContentPage
    {
        EpisodeDetailViewModel viewModel;
        public EpisodeDetailPage(EpisodeDetailViewModel viewModel)
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
            await Navigation.PushModalAsync(new NavigationPage(new EditEpisodePage(new EditEpisodeViewModel(viewModel.Episode))));
        }

        private async void DeleteBtn_Clicked(object sender, EventArgs e)
        {
            viewModel.Delete();
            await Navigation.PopModalAsync();
        }
    }
}