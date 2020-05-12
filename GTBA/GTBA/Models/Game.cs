using System;
using System.Collections.Generic;
using System.Text;

namespace GTBA.Models
{
    public class Game
    {
        public int GameId { get; set; }
        public string GameName { get; set; }

        public int FranchiseId { get; set; }
        public Franchise Franchise { get; set; }
    }
}
