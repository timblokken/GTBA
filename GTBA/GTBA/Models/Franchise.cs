using System;
using System.Collections.Generic;
using System.Text;

namespace GTBA.Models
{
    public class Franchise : BaseModel
    {
        //id of the franchise
        //Primary Key , auto incremented
        private int franchiseId;
        public int FranchiseId
        {
            get { return franchiseId; }
            set { SetProperty(ref franchiseId, value); }
        }

        //Name of the franchise
        private string franchiseName = string.Empty;
        public string FranchiseName
        {
            get { return franchiseName; }
            set { SetProperty(ref franchiseName, value); }
        }

        private string description = string.Empty;
        public string Description
        {
            get { return description; }
            set { SetProperty(ref description, value); }
        }

        public ICollection<Movie> Movies { get; set; }
        public ICollection<Serie> Series { get; set; }
        public ICollection<Game> Games { get; set; }
    }
}
