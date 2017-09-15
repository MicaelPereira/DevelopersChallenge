using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Championship.Entities
{
    public class Result : Base
    {
        public int IdLeague { get; set; }
        public virtual League League { get; set; }
        public int IdHost { get; set; }
        public virtual Team Host { get; set; }
        public int IdVisitor { get; set; }
        public virtual Team Visitor { get; set; }
        public decimal? HostResult { get; set; }
        public decimal? VisitorResult { get; set; }
    }
}
