using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Championship.Entities
{
    public class League : Base
    {
        public League()
        {
            Exceptions = new List<string>();
        }
        public string Name { get; set; }
        public int SumTeams { get; set; }
        public bool IsRandom { get; set; }
        public virtual List<Team> Teams { get; set; }
        public virtual List<Result> Results { get; set; }

        public List<string> Exceptions { get; set; }

        public bool IsOddTeam()
        {
            var valid = (Teams != null && Teams.Count > 0 && Teams.Count % 2 != 0);
            if (valid)
                this.Exceptions.Add("Teams is odd");
            return valid;
        }
    }
}
