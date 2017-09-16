using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Championship.Models
{
    public abstract class Base
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

    }
}