using System;
using System.Collections.Generic;
using System.Text;

namespace GTBA.Models
{
    public class Game : BaseModel
    {
        int gameId = -1;
        public int GameId
        {
            get { return gameId; }
            set { SetProperty(ref gameId, value); }
        }

        string gameName = string.Empty;
        public string GameName
        {
            get { return gameName; }
            set { SetProperty(ref gameName, value); }
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
