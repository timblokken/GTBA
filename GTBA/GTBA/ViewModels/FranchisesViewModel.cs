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
                "Item 1",
                "Item 2",
                "Item 3",
                "Item 4",
                "Itemssss 5"
            };
        }

    }
}
