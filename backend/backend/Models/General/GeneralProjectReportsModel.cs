using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Models.General
{
    public class GeneralProjectReportsModel
    {
        public int ongoingProjects { get; set; }
        public int completedProjects { get; set; }
        public int notStartedProjects { get; set; }
        public int pausedProjects { get; set; }
    }
}
