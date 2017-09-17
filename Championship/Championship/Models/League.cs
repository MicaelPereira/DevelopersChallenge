using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Championship.Models
{
    public class League : Base
    {
        public string Name { get; set; }
        public int SumTeams { get; set; }
        public bool IsRandom { get; set; }
        public List<Team> Teams { get; set; }
        public List<Result> Results { get; set; }
        public string hdnTeamsInLeague { get; set; }
    }
}