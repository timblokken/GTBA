using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace GTBA.ViewModels
{
    public class MoviesViewModel : BaseViewModel
    {
        public ObservableCollection<string> Items { get; set; }
        public MoviesViewModel()
        {
            Items = new ObservableCollection<string>
            {
                "movie 1",
                "movie 2",
                "movie 3",
                "movie 4",
                "movie 5"
            };
        }
    }
}
