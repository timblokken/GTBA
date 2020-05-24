using GTBA.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GTBA.ViewModels
{
    public class FranchiseTabbedViewModel : BaseViewModel
    {
        MoviesViewModel moviesViewModel;
        SeriesViewModel seriesViewModel;
        GamesViewModel gamesViewModel;

        public FranchiseTabbedViewModel(Franchise franchise)
        {
            Title = franchise.FranchiseName;

            //moviesViewModel = new MoviesViewModel(franchise);
            //seriesViewModel = new SeriesViewModel(franchise);
            //gamesViewModel = new GamesViewModel(franchise);

            moviesViewModel = new MoviesViewModel();
            seriesViewModel = new SeriesViewModel();
            gamesViewModel = new GamesViewModel();
        }
    }
}
