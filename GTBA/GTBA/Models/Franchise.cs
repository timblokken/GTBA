using System;
using System.Collections.Generic;
using System.Text;

namespace GTBA.Models
{
    public class Franchise : BaseModel
    {
        //public int FranchiseId { get; set; }

        int franchiseId;
        public int FranchiseId
        {
            get { return franchiseId; }
            set { SetProperty(ref franchiseId, value); }
        }

        string franchiseName = string.Empty;
        public string FranchiseName
        {
            get { return franchiseName; }
            set { SetProperty(ref franchiseName, value); }
        }

        public ICollection<Movie> Movies { get; set; }
    }
}
