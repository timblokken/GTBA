using GTBA.ViewModels.Games;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GTBA.Views.Games
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GameDetailPage : ContentPage
    {
        GameDetailViewModel viewModel;
        public GameDetailPage(GameDetailViewModel viewModel)
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
            await Navigation.PushModalAsync(new NavigationPage(new EditGamePage(new EditGameViewModel(viewModel.Game))));
        }

        private async void DeleteBtn_Clicked(object sender, EventArgs e)
        {
            viewModel.Delete();
            await Navigation.PopModalAsync();
        }
    }
}