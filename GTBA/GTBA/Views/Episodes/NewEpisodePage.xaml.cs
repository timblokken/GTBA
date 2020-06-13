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
    public partial class NewEpisodePage : ContentPage
    {
        NewEpisodeViewModel viewModel;
        public NewEpisodePage(Serie serie = null)
        {
            InitializeComponent();

            BindingContext = viewModel = new NewEpisodeViewModel(serie);

            if (serie != null)
            {
                SeriePicker.IsEnabled = false;
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

        private void addTagBtn_Clicked(object sender, EventArgs e)
        {
            string tag = TagEntry.Text.Trim();
            viewModel.AddTag(tag);
            TagEntry.Text = "";
        }
    }
}