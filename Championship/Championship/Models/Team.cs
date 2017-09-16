using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Championship.Models
{
    public class Team : Base
    {
        public string Name { get; set; }
        public League League { get; set; }
        public int IdLeague { get; set; }
    }
}