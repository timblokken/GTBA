using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using GTBA.Services;
using GTBA.Views;

namespace GTBA
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<FranchisesDataStore>();
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
