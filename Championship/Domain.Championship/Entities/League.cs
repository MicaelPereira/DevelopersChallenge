using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Championship.Entities
{
    public class League : Base
    {
        public string Name { get; set; }
        public int SumTeams { get; set; }
        public bool IsRandom { get; set; }
        public virtual List<Team> Teams { get; set; }
        public virtual List<Result> Results { get; set; }
    }
}
