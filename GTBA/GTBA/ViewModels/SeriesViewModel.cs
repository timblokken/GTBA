using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace GTBA.ViewModels
{
    public class SeriesViewModel : BaseViewModel
    {
        public ObservableCollection<string> Items { get; set; }
        public SeriesViewModel()
        {
            Items = new ObservableCollection<string>
            {
                "Serie 1",
                "Serie 2",
                "Serie 3",
                "Serie 4",
                "Serie 5"
            };
        }
    }
}
