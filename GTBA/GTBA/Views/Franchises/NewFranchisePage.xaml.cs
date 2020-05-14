using GTBA.Models;
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

        public Franchise Franchise { get; set; }
        public NewFranchisePage()
        {
            InitializeComponent();

            Franchise = new Franchise();

            BindingContext = this;
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "AddFranchise", Franchise);
            await Navigation.PopModalAsync();
        }

        async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}