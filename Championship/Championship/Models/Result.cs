using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Championship.Models
{
    public class Result : Base
    {
        public int IdLeague { get; set; }
        public League League { get; set; }
        public int IdHost { get; set; }
        public Team Host { get; set; }
        public int IdVisitor { get; set; }
        public Team Visitor { get; set; }
        public decimal? HostResult { get; set; }
        public decimal? VisitorResult { get; set; }
    }
}