using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace GTBA.ViewModels
{
    public class GamesViewModel : BaseViewModel
    {
        public ObservableCollection<string> Items { get; set; }
        public GamesViewModel()
        {
            Items = new ObservableCollection<string>
            {
                "game 1",
                "game 2",
                "game 3",
                "game 4",
                "game 5"
            };
        }
    }
}
