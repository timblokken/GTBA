﻿using GTBA.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace GTBA.ViewModels.Franchises
{
    public class NewFranchiseViewModel : BaseViewModel
    {
        public Franchise Franchise { get; set; }
        public NewFranchiseViewModel()
        {
            Franchise = new Franchise();
            DeleteTagCommand = new Command(tag => ExecuteDeleteTagCommand((string)tag));
        }

        public void Save()
        {
            Franchise.Tags = SerializeTags();
            MessagingCenter.Send(this, "AddFranchise", Franchise);
        }
    }
}
