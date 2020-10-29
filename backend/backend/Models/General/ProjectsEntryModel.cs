using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Models.General
{
    public class ProjectsEntryModel
    {
        public string quarter { get; set; }
        public double mouldingTechProjects { get; set; }
        public double physicalMetallurgyProjects { get; set; }
        public double foundryTechProjects { get; set; }
        public double supportTechProjects { get; set; }
        public double otherProjects { get; set; }
        public double total { get; set; }
    }

}
