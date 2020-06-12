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
    public partial class NewFranchisePage : ContentPage
    {
        NewFranchiseViewModel viewModel;
        
        public NewFranchisePage()
        {
            InitializeComponent();

            BindingContext = viewModel = new NewFranchiseViewModel();
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