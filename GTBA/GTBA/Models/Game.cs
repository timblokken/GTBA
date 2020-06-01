using System;
using System.Collections.Generic;
using System.Text;

namespace GTBA.Models
{
    public class Game : BaseModel
    {
        //id of the game
        //Primary Key , auto incremented
        private int gameId;
        public int GameId
        {
            get { return gameId; }
            set { SetProperty(ref gameId, value); }
        }

        //Name of the game
        private string gameName = string.Empty;
        public string GameName
        {
            get { return gameName; }
            set { SetProperty(ref gameName, value); }
        }

        private string description = string.Empty;
        public string Description
        {
            get { return description; }
            set { SetProperty(ref description, value); }
        }

        //id of the franchise the game is in
        //foreign key
        private int franchiseId;
        public int FranchiseId
        {
            get { return franchiseId; }
            set { SetProperty(ref franchiseId, value); }
        }
        public Franchise Franchise { get; set; }
    }
}
