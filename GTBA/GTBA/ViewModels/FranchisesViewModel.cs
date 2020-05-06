using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace GTBA.ViewModels
{
    public class FranchisesViewModel : BaseViewModel
    {
        public ObservableCollection<string> Items { get; set; }

        public FranchisesViewModel()
        {
            Title = "GTBA";

            Items = new ObservableCollection<string>
            {
                "franchise 1",
                "franchise 2",
                "franchise 3",
                "franchise 4",
                "franchise 5"
            };
        }

    }
}
