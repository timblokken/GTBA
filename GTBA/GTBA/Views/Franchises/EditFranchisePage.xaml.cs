﻿using GTBA.ViewModels.Franchises;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GTBA.Views.Franchises
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditFranchisePage : ContentPage
    {
        FranchiseDetailViewModel viewModel;
        public EditFranchisePage(FranchiseDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "EditFranchise", viewModel.Franchise);
            await Navigation.PopModalAsync();
        }

        async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}