﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bug_Tracker.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string ManagerId { get; set; }
        public virtual ApplicationUser Manager { get; set; }
        public string Name { get; set; }
        public virtual List<ProjectDev> Developers { get; set; }

        public Project()
        {
            Developers = new List<ProjectDev>();
        }
    }
}