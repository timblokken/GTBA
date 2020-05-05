using System;
using System.Collections.Generic;
using System.Text;

namespace GTBA.ViewModels
{
    public class FranchisesViewModel : BaseViewModel
    {

        public FranchisesViewModel()
        {
            Title = "GTBA";
        }

        private string title;

        public string Title
        {
            get { return title; }
            set { title = value; }
        }

    }
}
