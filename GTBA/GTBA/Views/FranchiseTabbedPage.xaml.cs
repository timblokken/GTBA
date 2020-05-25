using GTBA.Models;
using GTBA.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GTBA.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FranchiseTabbedPage : TabbedPage
    {
        FranchiseTabbedViewModel viewModel;
        public FranchiseTabbedPage(FranchiseTabbedViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;

            this.Children.Add(new MoviesListPage(viewModel.MoviesViewModel));
            this.Children.Add(new SeriesListPage(viewModel.SeriesViewModel));
            this.Children.Add(new GamesListPage(viewModel.GamesViewModel));
        }
    }
}