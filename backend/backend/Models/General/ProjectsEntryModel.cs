using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Models.General
{
    public class ProjectsEntryModel
    {
        public string quarter { get; set; }
        public int mouldingTechProjects { get; set; }
        public int physicalMetallurgyProjects { get; set; }
        public int foundryTechProjects { get; set; }
        public int supportTechProjects { get; set; }
        public int otherProjects { get; set; }
        public int total { get; set; }
    }
}
