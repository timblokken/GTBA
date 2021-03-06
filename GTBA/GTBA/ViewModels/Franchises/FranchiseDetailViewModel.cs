﻿using GTBA.Models;
using GTBA.Services;
using GTBA.Services.Interfaces;
using GTBA.Views.Franchises;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace GTBA.ViewModels.Franchises
{
    public class FranchiseDetailViewModel : BaseViewModel
    {
        public IFranchisesDataStore DataStore => DependencyService.Get<IFranchisesDataStore>();
        public Franchise Franchise { get; set; }

        public FranchiseDetailViewModel(Franchise franchise = null)
        {
            Title = franchise?.FranchiseName;
            Franchise = franchise;
            DeserializeTags();

            MessagingCenter.Subscribe<EditFranchiseViewModel, Franchise>(this, "EditFranchise", async (obj, update) =>
            {
                Franchise = update;
                Title = update.FranchiseName;
                DeserializeTags();
                await DataStore.UpdateItemAsync(update);
            });
        }

        public void Delete()
        {
            MessagingCenter.Send(this, "DeleteFranchise", Franchise);
        }

        public void DeserializeTags()
        {
            Tags.Clear();
            string[] tags = Franchise.Tags.Split('#');
            foreach (string tag in tags)
            {
                Tags.Add(tag);
            }
        }


    }
}
