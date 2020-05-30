using GTBA.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GTBA.ViewModels
{
    public class FranchiseTabbedViewModel : BaseViewModel
    {
        public MoviesViewModel MoviesViewModel { get; set; }
        public SeriesViewModel SeriesViewModel { get; set; }
        public GamesViewModel GamesViewModel { get; set; }

        public FranchiseTabbedViewModel(Franchise franchise)
        {
            Title = franchise.FranchiseName;

            MoviesViewModel = new MoviesViewModel(franchise);
            SeriesViewModel = new SeriesViewModel(franchise);
            GamesViewModel = new GamesViewModel(franchise);
        }
    }
}
