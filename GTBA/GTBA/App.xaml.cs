using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using GTBA.Services;
using GTBA.Views;
using GTBA.Services.DataStores;

namespace GTBA
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<FranchisesDataStore>();
            DependencyService.Register<MovieDataStore>();
            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
