using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bug_Tracker.Models
{
    public class Tickets
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description{ get; set; }
    }
}