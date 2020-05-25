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
            DependencyService.Register<SeriesDataStore>();
            DependencyService.Register<GamesDataStore>();

            MainPage = new NavigationPage(new MainPage());
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
