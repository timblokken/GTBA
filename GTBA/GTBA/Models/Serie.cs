﻿using System;
using System.Collections.Generic;
using System.Text;

namespace GTBA.Models
{
    public class Serie : BaseModel
    {
        int serieId = -1;
        public int SerieId
        {
            get { return serieId; }
            set { SetProperty(ref serieId, value); }
        }

        string serieName = string.Empty;
        public string SerieName
        {
            get { return serieName; }
            set { SetProperty(ref serieName, value); }
        }

        int franchiseId = -1;
        public int FranchiseId
        {
            get { return franchiseId; }
            set { SetProperty(ref franchiseId, value); }
        }
        public Franchise Franchise { get; set; }
    }
}
