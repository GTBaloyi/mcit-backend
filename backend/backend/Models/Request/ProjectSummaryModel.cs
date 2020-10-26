using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Models.Request
{
    public class ProjectSummaryModel
    {
        public int id { get; set; }
        public string projectNumber { get; set; }
        public string projectName { get; set; }
        public string projectDescription { get; set; }
        public string companyRegistrationNumber { get; set; }
        public string projectStatus { get; set; }
        public double projectProgress { get; set; }
        public string projectLeaderId { get; set; }
        public string projectLeaderName { get; set; }
        public string projectLeaderSurname { get; set; }
        public DateTime createdOn { get; set; }
    }
}
